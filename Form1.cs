//colocarei aqui todo o codigo de c# e em outro arquivo o codigo do desining



namespace listadeprodutos
{
    public partial class Form1 : Form
    {
        public Form1()

        {

            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //botao de adicionar item
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado na lista de produtos
            if (lst_produtos.SelectedItem != null)
            {
                // Obtém o item selecionado
                var produtoSelecionado = lst_produtos.SelectedItem;

                // Adiciona o item selecionado à lista do carrinho
                lst_carrinho.Items.Add(produtoSelecionado);

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
        private void button2_Click(object sender, EventArgs e)
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
                    var produtoSelecionado = lst_carrinho.SelectedItem;

                    //remove o produto selecionado
                    lst_carrinho.Items.Remove(produtoSelecionado);

                    // Exibe uma mensagem de confirmação
                    MessageBox.Show($"{produtoSelecionado} excluido do carrinho!");

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
        private void button5_Click (object sender, EventArgs e)
        {
            //pergunta se realmente deseja limpar a lista do carrinho
            var resultado = MessageBox.Show("Você realmente deseja remover este item do carrinho?",
                                             "Confirmar Remoção",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            // Se o usuário clicar em "Sim", limpa a lista do carrinho
            if (resultado == DialogResult.Yes)
            {

                lst_carrinho.Items.Clear();
            }

            else
            {
                //se resposta for diferente de sim, exibe esta mensagem e cancela a limpeza
                MessageBox.Show("processo de limpar carrinho cancelado");
            }
        }
    }
}
