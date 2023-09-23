// See https://aka.ms/new-console-template for more information
using Joao_Ramos_DR2_TP2;


const string returnCommand = "ESC";
const int tableWidth = 20;
const string PersistancePath = "./Data.json";

Screens currentScreen = Screens.main;
Screens lastScreen = Screens.exit;
Produto produtoEmFoco = new Produto("abacate", 23.00m);

List<Produto> produtos = Repos.Load(PersistancePath);
if (produtos == null)
    produtos = new List<Produto>();


while(currentScreen != Screens.exit)
{
	switch (currentScreen)
	{
		case Screens.main:
			mainScreen();
			break;
		case Screens.exit:
			break;
		case Screens.create:
			create();
			break;
		case Screens.update:
			update();
			break;
		case Screens.delete:
			delete();
			break;
		case Screens.list:
			list();
			break;
		case Screens.details:
			details();
			break;
		case Screens.search:
			search();
			break;
		default:
			break;
	}

    Repos.Save(produtos, PersistancePath);
}

void search()
{
    Produto encontrado = null;
    ScreenHelper.helperText($"digite {returnCommand} para voltar");
    
    while (encontrado == null)
    {
        Console.Write("Digite o nome do produto : ");
        string UserSearch = Console.ReadLine();
        encontrado = produtos.Find((Produto p) => p.nome == UserSearch);

        ScreenHelper.PrintError("produto não encontrado");

        if (UserSearch == "ESC")
        {
            currentScreen = lastScreen;
            return;
        }
    }

    produtoEmFoco = encontrado;
    currentScreen = Screens.details;
}

void details()
{
    Console.Clear();
    ScreenHelper.PrintHeader("Detalhes do produto");

    Table list = new Table("Nome,Preço", tableWidth);
    list.addEntry($"{produtoEmFoco.nome}|{produtoEmFoco.preco.ToString("C")}");
    list.printTable();

    string[] options = new string[]{
		"inicio",
		"editar",
		"deletar"
	};
	string chosen = ScreenHelper.GetOption(options);


    lastScreen = Screens.details;
    if (chosen == options[0]){
		currentScreen = Screens.main;
    }
    else if(chosen == options[1]){
        currentScreen = Screens.update;
    }
    else if (chosen == options[2]){
        currentScreen = Screens.delete;
    }
}

void mainScreen()
{
	Console.Clear();
    ScreenHelper.PrintHeader("Cadastro de Produtos");
    Console.WriteLine(" Digite a opção que deseja");

    string[] options = new string[]{
        "adicionar",
        "Pesquisar",
        "lista de produtos",
        "sair"
    };
    string chosen = ScreenHelper.GetOption(options);


    lastScreen = Screens.main;
    if (chosen == options[0])
    {
        currentScreen = Screens.create;
    }
    else if (chosen == options[1])
    {
        currentScreen = Screens.search;
    }
    else if (chosen == options[2])
    {
        currentScreen = Screens.list;
    }
    else if (chosen == options[3])
    {
        currentScreen = Screens.exit;
    }
}

void create()
{
    Console.Clear();

    ScreenHelper.PrintHeader("Adicionar produto");
    ScreenHelper.helperText($"digite {returnCommand} para voltar");

    Console.Write(" Nome :\t");
    string nome = Console.ReadLine();
    
    if(nome == returnCommand){
        currentScreen = lastScreen;
        return;
    }

    while (true)
    {
        Console.Write("Preço :\t");
        string preco = Console.ReadLine();
        preco = preco.Replace(".", ",");

        if (preco == returnCommand)
        {
            currentScreen = lastScreen;
            return;
        }

        lastScreen = Screens.create;
        if (Decimal.TryParse(preco, out decimal d))
        {
            Produto p = new Produto(nome, d);
            produtos.Add(p);
            produtoEmFoco = p;
            currentScreen = Screens.details;
            return;
        }
        else
        {
            ScreenHelper.PrintError("Este não é um preço válido");
        }
    }
}

void update()
{

    Console.Clear();

    ScreenHelper.PrintHeader("Adicionar produto");
    ScreenHelper.helperText($"digite {returnCommand} para voltar");
    ScreenHelper.helperText($"deixe em branco para manter o mesmo valor");

    Console.Write(" Nome :\t");
    string nome = ScreenHelper.getInputWithDefault(produtoEmFoco.nome);

    if (nome == returnCommand)
    {
        currentScreen = lastScreen;
        return;
    }

    while (true)
    {
        Console.Write("Preço :\t");
        string preco = ScreenHelper.getInputWithDefault(produtoEmFoco.preco.ToString());
        preco = preco.Replace(".", ",");

        if (preco == returnCommand)
        {
            currentScreen = lastScreen;
            return;
        }

        lastScreen = Screens.create;
        if (Decimal.TryParse(preco, out decimal d))
        {
            Produto p = new Produto(nome, d);
            produtos.Remove(produtoEmFoco);
            produtos.Add(p);
            produtoEmFoco = p;
            currentScreen = Screens.details;
            return;
        }
        else
        {
            ScreenHelper.PrintError("Este não é um preço válido");
        }
    }
}

void delete()
{

    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.Write(" VOCÊ TEM CERTESA QUE DESEJA DELETAR ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(produtoEmFoco.nome + " ? ");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;

    string[] options = new string[]{
        "Sim",
        "Não",
    };
    string chosen = ScreenHelper.GetOption(options);

    if (chosen == options[0])
    {
        produtos.Remove(produtoEmFoco);
        currentScreen = Screens.main;
    }
    else if (chosen == options[1])
    {
        currentScreen = lastScreen;
    }
}

void list()
{
    Console.Clear();
    ScreenHelper.PrintHeader("Produtos cadastrados");
    Console.WriteLine();

    string[] TableHeader = new string[] { "Nome", "Preço" };
    Table list = new Table(TableHeader, tableWidth);
    foreach (var item in produtos)
    {
        list.addEntry($"{item.nome}|{item.preco.ToString("C")}");
    }
    list.printTable();


    string[] options = new string[]{
        "inicio",
        "adicionar",
        "pesquisar",
    };
    string chosen = ScreenHelper.GetOption(options);


    lastScreen = Screens.list;
    if (chosen == options[0])
    {
        currentScreen = Screens.main;
    }
    else if (chosen == options[1])
    {
        currentScreen = Screens.create;
    }
    else if (chosen == options[2])
    {
        currentScreen = Screens.search;
    }
}
