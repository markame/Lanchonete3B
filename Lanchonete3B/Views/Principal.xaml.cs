using Lanchonete3B.Model;

namespace Lanchonete3B.Views;

public partial class Principal : ContentPage
{
	private Produto produto;
	public Principal()
	{
		InitializeComponent();
		produto = new Produto();
		GetAllProdutos();
    }
	protected async  void GetAllProdutos()
	{
		
		var produtos = await produto.getAllProduto("https://cactusapi.doppelganger.com.br/api/produtos");
		ProdutosCollectionView.ItemsSource = produtos;
    }
}