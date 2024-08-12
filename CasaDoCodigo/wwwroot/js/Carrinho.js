
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
            alert(response.itemPedido.quantidade)
        });
        
    }
}

var carrinho = new Carrinho();
