# Instruções de utilização

## Instalação do Site

Para acessar o projeto publicado online na plataforma smarterasp.net, o usuário deve clicar no seguinte link:

http://smensga-001-site1.itempurl.com/

Caso deseje rodar o projeto localmente clonando este repositório, seguir as seguintes instruções:
- Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
- Tenha o Visual Studio Community 2022 e o SQL server instalados no seu computador;
- Abra o arquivo "App-comunicacao-escolar.sln" presente em src/App-comunicacao-escolar no Visual Studio Community 2022;
- Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
- Crie uma pasta chamada "AppEscolaMail" na pasta /C: do seu computador para recebimento dos emails (funcionalidade de envio de e-mails por enquanto cria apenas arquivos .eml locais na máquina do usuário em vez de enviar para o endereço de e-mail informado);
- Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;
- Após seguir essas etapas, o usuário deverá visualizar a homepage da aplicação;

## Histórico de versões

### [0.1.0] - 13/05/2022
#### Adicionado
- Implementação parcial das funcionalidades para entrega da etapa 3, RFs 1 até 9 implementados.
- Solução ainda não hospedada na internet, roda apenas de forma local.

### [0.2.0] - 11/06/2022
#### Adicionado
- Todas as funcionalidades da aplicação foram implementadas.
- Solução hospedada na plataforma smarterasp.net, podendo ser acessada através do link http://smensga-001-site1.itempurl.com/.
