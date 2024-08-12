
class Carrinho {
    getData(elemento) {
        debugger;
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = linhaDoItem.attr('item-id');
        var qtde = linhaDoItem.find('input').val();
        
        return {
            Id: itemId,
            Quantidade: qtde

        };
    }

    clickIncremento(btn) {
        var data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data)
    }

    clickDecremento(btn) {
        var data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data)
    }

    updateQuantidade(input) {
        var data = this.getData(input);
        this.postQuantidade(data)
    }

    

    postQuantidade(data) {
        $.ajax({
            url: '/pedido/PostQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            this.setQuantidade(response.itemPedido);
            this.setSubtotal(response.itemPedido);
            this.setTotal(response.carrinhoViewModel);
        }.bind(this));
        
    }
    setLinhaDoItem(itemPedido) {
        return $('[item-id=' + itemPedido.id + ']')
    }

    setQuantidade(itemPedido) {
        this.setLinhaDoItem(itemPedido)
        .find('input').val(itemPedido.quantidade)
    }

    setSubtotal(itemPedido) {
        this.setLinhaDoItem(itemPedido)
            .find('[subtotal]').html(itemPedido.subtotal.duasCasas());
    }
    setTotal(carrinhoViewModel) {
        $('[total]').html(carrinhoViewModel.total.duasCasas())
    }


}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.',',');
}
