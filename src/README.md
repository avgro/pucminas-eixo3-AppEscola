# Instruções de utilização

## Instalação do Site

Na etapa atual, o projeto ainda não foi hospedado em nenhum serviço de hospedagem e deve portanto, ser rodado localmente na máquina do usuário, para fazer isso, o usuário deve seguir as seguintes instruções:

- Faça o download do arquivo do projeto (ZIP) ou clone do projeto no GitHub;
- Tenha o Visual Studio Community 2022 e o SQL server instalados no seu computador;
- Abra o arquivo "App-comunicacao-escolar.sln" presente em <a href="src/App-comunicacao-escolar"> src/App-comunicacao-escolar</a> no Visual Studio Community 2022;
- Execute o comando "update-database" no console do Package Manager para criar as tabelas do banco de dados localmente através dos arquivos "migrations" do Entity Framework Core;
- Crie uma pasta chamada "AppEscolaMail" na pasta /C: do seu computador para recebimento dos emails (funcionalidade de envio de e-mails por enquanto cria apenas arquivos .eml locais na máquina do usuário em vez de enviar para o endereço de e-mail informado);
- Rode o projeto no Visual Studio, que abrirá uma janela do browser no endereço localhost:7060;

## Histórico de versões

### [0.1.0] - 13/05/2022
#### Adicionado
- Implementação parcial das funcionalidades para entrega da etapa 3, RFs 1 até 9 implementados.
- Solução ainda não hospedada na internet, roda apenas de forma local.
