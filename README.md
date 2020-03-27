# Iti Case

## Execução

Para executar a aplicação, é necessário ter instalado o __Visual Studio 2019__ ou o __Visual Studio Code__ e também a __SDK 3.1 do dotnetcore__.

### Visual Studio 2019

Dê dois cliques no arquivo _ItiCaseAPI.sln_, ele abrirá o Visual Studio. \
Após carregar os dois projetos, clique com o botão direito do mouse no projeto de nome _ItiCaseAPI_ e selecione a opção _Set as StartUp Project_. \
Aperte _F5_ e a aplicação irá rodar na porta __44366__. 

### Visual Studio Code

Abra o Visual Studio Code e selecione a pasta raíz da aplicação. 
Após o VSCode carregar os dois projetos, abra um terminal com __CTRL+SHIFT+'__ e execute o comando `cd .\ItiCase.API\` e depois execute 
`dotnet run`.
A aplicação irá rodar na porta __44366__. 

### Chamada da API (Via Postman)

Para facilitar as chamadas, na pasta raíz do repositório existe um arquivo chamado _ItiCase.postman_collection.json_. 
Este arquivo tem sete chamadas para a API para testar diferentes inputs na requisição.

### Testes

Está disponível no projeto de testes os testes integrados e de unidade. Como se trata de uma funcionalidade simples, ambos são muito parecidos
a diferença se encontra na garantia de retornar um __StatusCode 200__ nas requisições do teste integrado.

### Considerações

Por se tratar de uma funcionalidade simples, achei prudente criar apenas uma classe estática para auxiliar nesta validação. \
Acredito que a facilidade da leitura e a simplicidade do código são primordiais. \
Fiz o desenvolvimento _as-is_, sem ficar pensando demais no que pode acontecer no futuro.
