## Joao_Ramos_DR2_AT
Repositorio criado para a entrega do assessment da disciplina de introducao a C#

### Enunciado
Com o objetivo de praticar tudo o que foi aprendido na disciplina de Fundamentos de Desenvolvimento com C#,
nesse Assessment, voce deve criar, com o Visual Studio, uma aplicacao (Console, .NET Core) de gerenciamento
de uma entidade (baseado em um tema escolhido pelo aluno, segundo regras definidas pelo professor nas 
primeiras aulas da disciplina).

Desenvolva um CRUD completo, disponibilizando em sua aplicacao quatro menus principais (inclusao, alteracao,
exclusao e pesquisa).

Exibicao das ultimas cinco entidades cadastradas ao iniciar aplicacao: Ao executar a aplicacao, antes de 
exibir os menus principais, exiba as cinco ultimas entidades cadastradas na aplicacao. Caso nao exista 
entidade cadastrada, pode opcionalmente ser exibida uma mensagem indicando que nao existe entidade 
cadastrada. E possivel que a aplicacao tenha menos de 5 entidades cadastradas, e sendo este o caso, deve 
ser exibido o numero total de entidades cadastradas.

Menu de inclusao: No menu de inclusao, a aplicacao deve solicitar que o usuario informe os dados da 
entidade. Apos o informe dos dados, a aplicacao deve incluir a entidade no repositorio.

Menu de alteracao: No menu de alteracao, a aplicacao deve oferecer uma opcao para pesquisar uma entidade, 
exibir os dados atuais da entidade pesquisada e solicitar que o usuario informe os novos dados da entidade 
para alteracao. Apos o informe dos dados, a aplicacao deve alterar a entidade com as novas informacoes no 
repositorio.

Menu de exclusao: No menu de exclusao, a aplicacao deve oferecer uma opcao para pesquisar uma entidade, 
exibir os dados atuais da entidade pesquisada e pedir confirmacao para exclusao da entidade. Apos 
confirmacao do usuario, a aplicacao deve excluir a entidade do repositorio.

Menu de pesquisa: No momento da pesquisa, a aplicacao deve solicitar que o usuario informe uma cadeia de 
caracteres ou ID contendo a informacao a ser pesquisada nas entidades. A aplicacao deve realizar pesquisa 
na propriedade string (exemplo: nome do medico, nome da escola, nome do carro, etc) das entidades 
"persistidas" ou pelo ID. A aplicacao deve exibir o campo string (completo) de cada entidade encontrada na 
pesquisa e uma Opcao numerica para visualizar os detalhes da entidade. Opcao de visualizar o detalhe da 
entidade: Quando o usuario informar a Opcao numerica no resultado da pesquisa, a aplicacao deve exibir os 
detalhes da entidade com todas as suas informacoes e mais o resultado de um metodo da entidade que realize 
calculo com a propriedade do tipo DateTime.

*** [IMPORTANTE] E preciso que o usuario tenha a Opcao de cadastrar em um arquivo ou em uma lista, antes mesmo de 
comecar a manipular os cadstros.

E obrigatoria o uso de classe para representar a sua entidade (baseado no tema escolhido pelo aluno).

E obrigatorio que a entidade tenha pelos menos cinco propriedades (cada propriedade com tipos diferentes: 
string, DateTime, int, bool, double, Guid, etc).

E obrigatorio que exista um projeto (camada de apresentacao) do tipo console para obtencao de entradas 
(inputs) e exibicao de saidas (outputs).

E obrigatorio que exista um projeto (camada de negocio) do tipo Class Library contendo a classe referente a 
entidade do seu tema.

E obrigatorio que exista um projeto (camada de dados) do tipo Class Library contendo dois repositorios. O 
primeiro repositorio deve realizar leitura/escrita das entidades em arquivo. O segundo repositorio deve 
realizar leitura/escrita das entidades em uma colecao em memoria (colecao pode ser de qualquer tipo).

Desenvolva uma interface contendo assinatura dos metodos para as operacoes de leitura/escrita de entidade 
(inclusao, alteracao, exclusao, pesquisa, etc). Os repositorios existentes na aplicacao devem implementar a
interface. Na entrega, seu codigo deve utilizar apenas o repositorio que realizar leitura/escrita em 
arquivo, mas na correcao os dois repositorios serao testados.

Entregue seu projeto de acordo com as boas praticas de codificacao demonstradas ao longo da disciplina. 
Nome de variaveis com boa semantica, visibilidade de propriedades definidas corretamente (privado, publica)
e metodos pequenos serao considerados na avaliacao.