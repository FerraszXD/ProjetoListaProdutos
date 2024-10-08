
namespace listadeprodutos
{
    public partial class Form1 : Form
    {
        public Form1()

        {

            InitializeComponent();
            //puxa a funcao de carregar os produtos na lista
            CarregarProdutos();

        }

        private void CarregarProdutos()
        {
            // Cria produtos com nome e preço
            lst_produtos.Items.Add(new Produto("The Legend of Zelda: Breath of the Wild", 59.99m, "C:\\Users\\Ferrasz\\source\\repos\\listadeprodutos\\imagens\\zelda.png"));
            lst_produtos.Items.Add(new Produto("Super Mario Odyssey", 49.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("Red Dead Redemption 2", 39.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("The Witcher 3: Wild Hunt", 29.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("Dark Souls III", 19.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("God of War", 59.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("Minecraft", 26.95m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("Fortnite", 0.00m, "C:\\Users\\Ferrasz\\source\\repos\\listadeprodutos\\imagens\\fortimite.png"));
            lst_produtos.Items.Add(new Produto("Call of Duty: Modern Warfare", 59.99m, "imagens/dark_souls.jpg"));
            lst_produtos.Items.Add(new Produto("Animal Crossing: New Horizons", 49.99m, "imagens/dark_souls.jpg"));
        }

        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public string ImagemCaminho { get; set; } // Caminho da imagem

            public Produto(string nome, decimal preco, string imagemCaminho)
            {
                Nome = nome;
                Preco = preco;
                ImagemCaminho = imagemCaminho;
            }

            public override string ToString()
            {
                return Nome; // Exibe o nome do produto na lista
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private decimal totalCarrinho = 0m; // Variável para armazenar o total
        //botao de adicionar item
        private void btn_adicionar_Click_1(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado na lista de produtos
            if (lst_produtos.SelectedItem != null)
            {
                // Obtém o item selecionado e o converte para Produto
                Produto produtoSelecionado = (Produto)lst_produtos.SelectedItem;

                // Adiciona o item selecionado à lista do carrinho
                lst_carrinho.Items.Add(produtoSelecionado);
                totalCarrinho += produtoSelecionado.Preco;

                // Exibe o total atualizado
                lbl_total.Text = $"Total: R$ {totalCarrinho:F2}";

                // Exibe uma mensagem de confirmação
                MessageBox.Show($"{produtoSelecionado} adicionado ao carrinho!");
            }
            else
            {
                // Caso nenhum item esteja selecionado, avisa o usuário
                MessageBox.Show("Selecione um produto para adicionar ao carrinho.");
            }
        }


        //botao de excluir item
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado na lista do carrinho
            if (lst_carrinho.SelectedItem != null)
            {
                // Pergunta ao usuário se ele realmente deseja remover o item
                var resultado = MessageBox.Show("Você realmente deseja remover este item do carrinho?",
                                                 "Confirmar Remoção",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                // Se o usuário clicar em "Sim", remove o item
                if (resultado == DialogResult.Yes)
                {


                    // Obtém o item selecionado
                    Produto itemSelecionado = (Produto)lst_carrinho.SelectedItem;

                    //remove o produto selecionado
                    lst_carrinho.Items.Remove(itemSelecionado);

                    // Atualiza o total do carrinho
                    totalCarrinho -= itemSelecionado.Preco;
                    lbl_total.Text = $"Total: R$ {totalCarrinho:F2}";

                    // Exibe uma mensagem de confirmação
                    MessageBox.Show($"{itemSelecionado} excluido do carrinho!");

                }
                else
                {
                    // Obtém o item selecionado
                    var produtoSelecionado = lst_carrinho.SelectedItem;

                    // Caso nenhum item esteja selecionado, avisa o usuário
                    MessageBox.Show($"{produtoSelecionado} nao removido do carrinho");

                }

            }
            else
            {
                // Caso nenhum item esteja selecionado, avisa o usuário
                MessageBox.Show("Selecione um produto para excluir do carrinho.");

            }
        }


        //botao de limpar
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            //pergunta se realmente deseja limpar a lista do carrinho
            var resultado = MessageBox.Show("Você realmente deseja remover este item do carrinho?",
                                             "Confirmar Remoção",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            // Se o usuário clicar em "Sim", limpa a lista do carrinho
            if (resultado == DialogResult.Yes)
            {
                //reseta o valor e limpa o carrinho
                totalCarrinho = 0;
                lbl_total.Text = "R$0";
                lst_carrinho.Items.Clear();
            }

            else
            {
                //se resposta for diferente de sim, exibe esta mensagem e cancela a limpeza
                MessageBox.Show("processo de limpar carrinho cancelado");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
          //funcao de clique na lista
        private void lst_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_produtos.SelectedItem != null)
            {
                Produto produtoSelecionado = (Produto)lst_produtos.SelectedItem;

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                if (System.IO.File.Exists(produtoSelecionado.ImagemCaminho))
                {
                    try
                    {
                        // Abre a imagem em um fluxo de memória para evitar bloqueio do arquivo
                        using (var tempImage = new Bitmap(produtoSelecionado.ImagemCaminho))
                        {
                            // Clona a imagem para o PictureBox (evita bloqueio de arquivo)
                            pictureBox1.Image = new Bitmap(tempImage);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}");
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Imagem não encontrada!");
                }
            }
        }


    }
}
