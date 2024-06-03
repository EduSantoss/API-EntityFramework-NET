<h1>DIO | Resumo parte 2 APIs e Entity Framework com .NET - Modulo 4</h1>

-> Aprender e desenvolver uma API, utilizando o Entity Framework para persistência de dados, juntamente com seus principais conceitos e funcionalidades.
<br>
[Digital Innovation One](https://www.dio.me/en)

## 📚 Documentação 
- [Documentação .NET](https://git-scm.com/doc)
- [Documentação C#](https://docs.github.com/pt)

## 💻 Resumos das Aulas

| Aulas | Resumos |
|-------|---------|
| Resumo sobre APIS e Entity Framework | [Resumos]() |


### API

-> Uma API (Application Programing Interface) é uma forma de comunicação entre computadores ou programas de computadores.

-> Basicamente um software que fornece informações para outro software.

-> APIs são basicamente dados brutos.

-> Exemplo: Plataforma da DIO, acessando videos e recursos que estão no Youtube.

-> Exemplo clássico: um restaurante, você não vai chegar para o cozinheiro e pedir a comida diretamente a ele, o papel dele é cozinhar !

```
     Application = cliente   ->>  Garçom = API  <<-  Server = cozinheiros
```
-> Entrada: Pedido que o cliente deseja.

-> Processamento: Ato de ir a cozinha pedir a solicitação e retornar quando estiver pronto.

-> Saida: Concluiu a requisição/pedido.

-> Exemplo 2: Acesso a um site de compras, compra em um website, ele chama uma API que registra a venda e processamento no banco de dados, e então retorna para a API que então retorna para o cliente a resposta.

#### API de Feriados

-> Nager.Date: retorna lista de feriados de diversos países. [Site NagerDate](https://date.nager.at/)

-> Como aplicar: Digamos que tenha uma aplicação, sistema que tenha o prazo de 3 dias úteis, queremos se saber se tem algum feriado nesses dias, caso tenha, adicionar mais um.

-> Pode ser feito manualmente no banco de dados e verificar as datas, porém existem feriados móveis que nem sempre caem nos mesmo dias, nesse caso seria útill utilizar a API do NagerDate.

-> Dentro do site ele explica como fazer isto.

->> Muito importante ler a documentação de como utilizar a API, lá é dito como deve ser feita a requisição.

->> Resposta caso ele não ache, Status: 404 (erro 404 - Not Found)

->> Outro erro caso troque os lugares de como devem ser passados os request pedidos, por exemplo, passar país no lugar do ano 

#### Response

-> O que a API vai retornar, cada uma trabalha de maneira diferente e retorna de maneiras diferentes.

-> Resposta da API do NagerDate

| Dados | O que retornam |
|-------|----------------|
|date | The date of the holiday | 
|localName | Local name |
|name | English name | 
|countryCode | ISO 3166-1 alpha-2 |
|fixed | Is this public holiday every year on the same date |
|global	| Is this public holiday in every county (federal state) |
|counties | If it is not global you found here the Federal states (ISO-3166-2) |
|launchYear	| The launch year of the public holiday |
|types | The types of the public holiday, several possible <br>- Public <br>- Bank (Bank holiday, banks and offices are closed) <br>- School (School holiday, schools are closed) <br>- Authorities (Authorities are closed) <br>- Optional (Majority of people take a day off) <br> - Observance (Optional festivity, no paid day off)

Retorno:

```
[
   {
      "date": "2017-01-01",
      "localName": "Neujahr",
      "name": "New Year's Day",
      "countryCode": "AT",
      "fixed": true,
      "global": true,
      "counties": null,
      "launchYear": 1967,
      "types": [
         "Public"
      ]
   },
   {
      "date": "2017-01-06",
      "localName": "Heilige Drei Könige",
      "name": "Epiphany",
      "countryCode": "AT",
      "fixed": true,
      "global": true,
      "counties": null,
      "launchYear": null,
      "types": [
         "Public"
      ]
   },
]   
```

-> Outro exemplo: Empresa de Ecommerce que vende os produtos e uma Empresa de transportes que vai levar o produto para o cliente final.

```
Empresa de Ecommerce  -->>  API de entregas  <<-- Empresa de Transportes
```
-> Empresa de transportes não precisa saber sobre como foi feito o pagamento do cliente. Só precisa de um comando da empresa de ecommerce, REQUISIÇÃO, para saber se deve entregar ou não e o endereço.

-> Já a empresa de ecommerce precisa saber e informar ao cliente em quanto tempo o produto vai ser entregue, que precisa ser passado pela empresa de transportes .

-> O andamento do pedido por exemplo poderia ser passado pela nota fiscal ou número de pedido, para consultar na base de dados dentro da empresa de transportes para saber onde está o pedido e então retornar a informação para a API que retorna para a empresa de ecommerce.

-> Para isso é preciso de uma API para comunicar elas, de maneira automática.

#### Outro cenário

-> Comunicação entre Frontend, Backend e Banco de dados.

```
 Frontend -->>  Backend  <<-- Banco de dados
```

-> Situação: um site de uma empresa que pode ser acessado só por funcionários da própria empresa para realizar cadastro de algumas informações, sem ser exposta externamente.

-> Ou seja, APIs também servem para comunicaçÕes em sistemas fechados dentro de uma mesma empresa.

#### API de Imagens de Cachorros

-> Dog API: maior coleção de imagens livres de uso de cachorros. [Site DogAPI](https://dog.ceo/dog-api/)

Retorno dela:

```
{
    "message": "https://images.dog.ceo/breeds/pomeranian/n02112018_2314.jpg",
    "status": "success"
}
```

#### Criando uma API

-> dotnet new webapi-> cria preparo para uma API

-> dotnet watch run -> toda operação feita não precisa ser parada e rodar de novo, ele fica observando os arquivos da api e caso identifique alguma mudança ele vai recompilar automaticamente.

-> Ou seja não precisa parar e executar de novo.

-> Ele cria automático um exemplo de hello world de API (api de tempo).

-> Caso seja parada a execução ele pergunta se deve voltar (responder com Y ou N)

-> Depois de criada classe UsuarioController (ver código), e atualizar, ele já pode ser chamado pela WebAPI e já aparece no Swagger.

### Documentar APIs

-> Swagger: conceito do .NET que servve para documentar uma API, serve para desenvolvedores testarem a API.

-> Ele é opcional, é uma ferramente que auxilia na documentação e teste, serve para facilitar a vida.

-> API criada localmente (localhost).

#### Controller

-> Uma classe que vai agrupar suas requisições HTTP e disponibilizar seus endpoints.

-> Agrupar todas as ações em comum, classes em comum e colocar na Controller.

-> Exemplo: Vamos supor que se tem uma API que atualiza os usuários, cria-se então o usuario.controller, e tudo que
fizer na usuários, como busca por id, atualizar usuário, deletar usuário, será atualizado na usuario.controller.

-> Para uma atualização de digamos produto, ai será criada outra controller, produto.controller.

#### Entendendo as Rotas

-> Controllers é pasta de entrada principal da API.

-> Parte controller é ignorada no nome, mas serve para identificar um padrão que serão identificadas na API, o caminho dela e no Swagger.

-> Exemplo desse caminho: Classe usuario -> 'https://localhost:7069/Usuario/ObterDataHoraAtual'

-> Nome que aparece do método disponibilizado: Perceber que o nome é diferente do método criado ObterDataHora() [HttpGet("ObterDataHoraAtual")], pois eles podem ser diferentes.


### Entity Framework

-> É um framework ORM (Object-Relational Mapping) criado para facilitar a integração com o banco de dados, mapeando tabelas e gerando comandos SQL de forma automática.

-> Até agora trabalhamos com dados em memória, que ao fechar os dados eram perdidos, mas agora é preciso que tenha a persistência desses dados.

-> Salvar um usuário, inserindo em uma API, e salva-lo em uma tabela dentro de um banco de dados.

-> Passar um comando para o C# para então ser executado no banco de dados.

-> O entity framework é capaz de abstrair toda a comunicação e geração do SQL a partir do C#, de forma automatica.

```
                          User Interface (UI)
                                |                          
                               /|\ 
                          BusinesseLayer     -> camada de negócios, classes, controller, onde recebe e trata dados
                                |
                               /|\
                          DataLayer (Entity Framework) -> camada mais próxima do banco de dados.
                                |
                               /|\
                            Database         
```

-> Ou seja, teremos uma classe por exemplo, usuario em meu programa, e uma tabela chamada usuario no banco de dados, e para elas se comunicarem será feito pelo entity framework.

-> Digamos que precisamos selecionar um usuário do banco (comando SELECT Nome FROM usuario), não precisa ser escrito um comando para isso, a ferramente já executa.

-> Em resumo, não precisamos nos preocupar com as querys a serem feitas no banco de dados, bastante facilitada pelo Entity Framework.

### CRUD

-> C = CREATE (Insert)

-> R = READ (Select)

-> U = UPDATE (Update)

-> D = DELETE (Delete)

->> Operações para trabalhar com banco de dados, CRUD é usado ao trabalhar com banco de dados

O que o Entity faz?

```
 Contatos                                              CREATE TABLE Contatos... 
 + Id: int                   Entity framework          INSERT INTO Contatos...              
 + Nome: string                  ----->>>              UPDATE Contatos...
 + Telefone: string                                    SELECT * FROM Contatos...
 + Ativo: bool                                         DELETE FROM Contatos...
```

-> Ao solicitar ou realizar algo no Entity framework ele vai traduzir para o SQL.

-> Exemplo: criada nova classe Contatos no programa, podemos usar o entity para criar uma tabela com nome também Contatos no banco de dados, poupando muito tempo de desenvolvimento. 

-> Parte ruim: pouca prática dos comandos SQL na veia.

#### Instalar ferramenta do Entity framework

-> Instalar apenas um vez, a partir dai, outros projetos já terão o entity instalado.

-> Ficar atento a versão, devido a estar usando o .NET 6.

```
dotnet tool install --global dotnet-ef --version 6.0.6
```
-> Chamar a ferramenta através do dotnet-ef

->> Instalar pacote Design
```
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.6
```
-> Pacote instalado a nível de projeto, precisa executar para todos os projetos

->> Instalar pacote do servidor desejado, no caso SqlServer
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.6 
```

#### Criando Classe chamada Contato

-> Objetivo é fazer um CRUD de contatos, semelhante a uma agenda.

-> Criar classe chamada Contatos (ver código), de resto o entity framework resolve.

->>>> IMPORTANTE: esta classe é uma entidade, toda entidade é uma classe que irá virar uma tabela no banco de dados.

#### Criando Contexto

-> Classe que centraliza todas as nossas informações em um banco de dados.

-> Criada AgendaContext, nome do database vai ser Agenda.

#### Cadastrando Conexão e Iniciando DbContext

-> Pastas appsettings.json, Conexão será cadastrada nessas pastas !!!.

-> appsettings.Development = usa só para teste, desenvolvimento.

-> appsettings.json = usado para produção, para implementar em um ambiente real.

-> Exemplo prático: Podemos indicar que quando estivermos no ambiente de desenvolvimento não vamos enviar email aos usuários, mas em produção ele irá enviar.

```
"EnviaEmail": false    -> Criado nos Json para exemplo
```

->>> Criar conexão, lembrar de iniciar banco de dados
```
"ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost\\sqlexpress;Initial Catalog=Agenda; Integrated Security=True"
  }
  
Entendendo: "Server=localhost\\sqlexpress"  -> endereço do server
Initial Catalog=Agenda     -> Entity framework vai criar o banco de dados que ainda não existe
Integrated Security=True   -> Autenticação sendo feita apenas pelo usuário do windows, já que estamos localmente
                              numa situação de produção seria aqui que passariamos login e senha   
```
-> Lembrando que a conexão acima pode variar a depender de local do banco, qual banco sendo utilizado.

-> Agora precisamos configurar o nosso context passando a string de conexão, para ele conseguir utilizar ela.

```
Abrir classe program.cs e adicionar código abaixo

builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

Entendendo: AddDbContext<AgendaContext>   -> Adicionando o database do tipo AgendaContext
options => options.UseSqlServer      -> Passando algumas opcoes, para usar o SqlServer
builder.Configuration                -> Pegando configuracao do appsettings
GetConnectionString                  -> Pegando alguma chave da connectionString no caso a "ConexaoPadrao" que foi
                                        criada

builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer("Server=localhost\\sqlexpress;Initial Catalog=Agenda; Integrated Security=True"));                    

-> Poderia ser feita desse jeito tambem, mas nao é recomendado, pois se precisar mudar terá que recompilar o programa, e desse jeito teria que está recompilando toda vez.
```

#### Migrations

-> Apesar do entity gerar os comandos da tabela de forma automatica, precisamos dizer ao entity que existem alterações no código que precisam ser refletidas no banco de dados.

-> Toda criação de tabela é necessário pedir ao entity para criar de maneira antecipada, chamada de migrations.

-> Migrations é basicamente um mapeamento feito pelo entity das classes para poder transformar elas eme tabelas.

-> Hora de usar o banco de dados, lembrar de usar ele.

```
dotnet-ef migrations add CriacaoTabelaContato    -> Nome é bom ser descritivo, pode ser qualquer um.

para remover:  dotnet ef migrations remove
```

-> Pasta chamada Migrations criada, aparecendo a data que foi criada.

-> Importante notar que as mundaças ainda não estão no banco de dados.

-> Execução:
```
dotnet-ef database update          -> Aplicando mudanças
```

-> Depois de uma dor de cabeça devido a permissão de adminstrador, consegui fazer rodar indo na pasta security e alterando permissões de criação e acesso.

-> Criado database Agenda no banco de dados, com tabela contatos, e uma tabela MigrationHistory que não deve ser mexida, irá apenas armazenar o histórico para não repetir ações, como tentar criar de novo.

#### Criando a Controller e os Endpoints 

-> Objetivo agora é botar um CRUD na tabela de Contato.

-> Enviando uma informação: [HttpPost] poderia passar algo mas não precisa.

-> Executar dotnet watch run

-> Para fazer um POST é necessário passar o request body, formato json.

-> No terminal aparece o que ele fez, depois de realizar o POST, realizado pelo próprio entity framework.

-> Informações já inseridas no database.

->> Lembrar que os endpoints são os métodos que realizam as ações !!!

Criando endpoint de CREATE para realizar um POST, ou seja, um INSERT INTO de dados na tabela.
```
  private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            // construtor
            _context = context;
        } 
         
        [HttpPost] 
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }
```
Continuando...

Criando endpoint READ, ou seja, um GET para o Id, tudo na ContatoController, basicamente um SELECT.
```
[HttpGet("{id}")]
public IActionResult ObterPorId(int id)
        {
            // Contatos representa nosso dbcontext
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();          -> title caso não encontre.
            }  

            return Ok(contato);
        }
```

Criando o endpoint de Update, método vai receber um id do contato que queremos atualizar, e recebe um contato, que é o json das informaçÕes que queremos que sejam atualizadas.

Realizado UPDATE na tabela do banco de dados.
```
[HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;   -> Basicamente pegando as informações que estao no banco
            contatoBanco.Ativo = contato.Ativo;           e atualizando pelas informações novas a serem postas.

            _context.Contatos.Update(contatoBanco);     -> atualizando propriamente o contato do banco.
            _context.SaveChanges();

            return Ok(contatoBanco);
        }
``` 
->> Utilizar Swagger para ver alterações.

Criando endpoint de DELETAR, retorno 204 significa sucesso mas que não retorna nada, já que ele foi deletado.

```
[HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();                  -> lembrar do saveChanges se não ele não salva lá no banco
            return NoContent();
        }
```
CRUD COMPLETO !!!

#### Agora vamos incrementar nosso método GET.

->> Podemos criar vários endpoints, para realizar difetens ações

Criando endpoint de obter por Nome, novo método GET, para permitir que ele filtre por Id e também por nome.

-->> Podemos criar várias maneiras de busca, inclusive passando mais de um parâmetro, inclusive fazendo eles sendo opcionais, passar um ou outro já traria o resultado.
``` 
[HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }
```

### Verbos HTTP

-> Ações que iriam ocorrer na API.

| HTTP Verb | CRUD | O que faz |
|-----------|------|-----------|
| POST | Create | Postando/Criando nova informação na API|
| GET | Read | Obter informações, relacionado com retorno da informação|
| PUT | Update/Replace | Atualiza informações, precisando passar tudo (Nome, telefone, Ativo)|
| PATCH | Update/MOdify | Semelhante ao PUT, porém não precisa passar informação completa|
| DELETE | Delete | Deletar informações desejadas| 

#### Recapitulando a construção da API

-> Lembrar da instalação dos pacotes, lembrar da versão, e de que preicisam ser instalados toda vez a nível de projeto.

-> Criação da conexão nas pastas appsettings (meu caso só na de desenvolvimento).

Precisa ter nome ConnectionStrings !!!
```
"ConnectionStrings": {
    "ConexaoPadrao": "Server=localhost\\sqlexpress; Initial Catalog=Agenda; Integrated Security=True"
  }
```

-> Criada pasta entities, que representa uma classe que também irá ser uma tabela no banco de dados.

-> Criado Context, que herda de DbContext, classe que vai acessar o banco de dados, precisa do construtor rebendo um options, e passando para classe dbcontext ( : base(options))

-> Dbset do tipo Contato, chamado de Contatos, que serve para acessar os registros da tabela Contatos chamando essa mesma propriedade.

-> Se não estiver no Dbset não será identificada com tabela.

-> Program.cs para passar a configuração para o dbconext, conexão do banco de dados para se conectar.
```
// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

->> options recebido na AgendaContext para acessar o servidor
->> "ConexaoPadrao" é a conexao cadastrada no JSON.
```

-> Criadas migrations, que é o código para espelhar as alterações no código dentro do banco de dados.

-> Não precisamos alterar, só validar as mundaças.

-> Mesmo criada a migration ela ainda não foi aplicada no database.
```
dotnet-ef migrations add CriacaoTabelaContato  
dotnet-ef database update
```

-> As controllers, ponto de entrada onde se disponibiliza os métodos (endpoints)

-> Herança de ControllerBase.

-> Receber via construtor o AgendaContext que nos permite acessar o banco de dados. Chamado de injeção de dependência.
```
[ApiController]
[Route("[controller]")] 

private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            // construtor
            _context = context;
        } 
```

-> Por último criação do CRUD, métodos/endpoints, para todos precisamos chamar o SaveChanges, com exceção do GET.

-> Utilizar o Swagger !!!.

#### Alterando endpoint Create


-> Trocar método OK para CreateAtAction().
```
return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);

-->> Após criar, para obter o registro recém criado, chame o ObterPorId e retorne o id recém criado ({ id = contato.Id }) e a própria informação do contato.

-> Isso para retornar um location, mostrando que foi criado e mostrando o recurso (https://localhost:7069/Contato/6)
```
  


