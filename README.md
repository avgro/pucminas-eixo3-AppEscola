# Aplicação de comunicação escolar para ensino fundamental e educação infantil

`CURSO: Análise e Desenvolvimento de Sistemas`

`DISCIPLINA: Eixo 2 - Projeto: Desenvolvimento de uma Aplicação Interativa`

`SEMESTRE: 1º Semestre de 2022` 

<p align="justify">Aplicação de comunicação escolar focada nos níveis de ensino fundamental e educação infantil que visa criar um sistema centralizado com envio de texto, imagens e vídeos entre 
os usuários cadastrados. Além do sistema de mensagens, a aplicação disponibilizará outras funções como o acesso a uma agenda escolar, um sistema de notificações e uma linha do tempo onde o professor poderá postar atualizações sobre o aluno para visualização exclusiva por seus responsáveis através de suas contas de usuário. O cadastro de novas contas de usuário (para professores, responsáveis do aluno e outros funcionários), disciplinas, turmas e alunos será realizado pela escola através de uma conta de administrador, que também poderá postar avisos e marcar eventos dentro do sistema.</p>

## Integrantes

* André Soares Alves da Silva
* André Vieira Grochowski
* Maria Luiza Silva Lacerda
* Robson Levi Mariano Eduardo
* Sergio Luiz de Menezes Filho
* Vania Maria Tiburzio Rezende


## Orientador

* José Wilson Da Costa 

## Instruções de utilização

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

# Documentação

<ol>
<li><a href="docs/01-Documentação de Contexto.md"> Documentação de Contexto</a></li>
<li><a href="docs/02-Especificação do Projeto.md"> Especificação do Projeto</a></li>
<li><a href="docs/03-Metodologia.md"> Metodologia</a></li>
<li><a href="docs/04-Projeto de Interface.md"> Projeto de Interface</a></li>
<li><a href="docs/05-Arquitetura da Solução.md"> Arquitetura da Solução</a></li>
<li><a href="docs/06-Template Padrão da Aplicação.md"> Template Padrão da Aplicação</a></li>
<li><a href="docs/07-Programação de Funcionalidades.md"> Programação de Funcionalidades</a></li>
<li><a href="docs/08-Plano de Testes de Software.md"> Plano de Testes de Software</a></li>
<li><a href="docs/09-Registro de Testes de Software.md"> Registro de Testes de Software</a></li>
<li><a href="docs/10-Plano de Testes de Usabilidade.md"> Plano de Testes de Usabilidade</a></li>
<li><a href="docs/11-Registro de Testes de Usabilidade.md"> Registro de Testes de Usabilidade</a></li>
<li><a href="docs/12-Apresentação do Projeto.md"> Apresentação do Projeto</a></li>
<li><a href="docs/13-Referências.md"> Referências</a></li>
</ol>

# Código

<li><a href="src/App-comunicacao-escolar"> Código Fonte</a></li>

# Apresentação

<li><a href="presentation"> Apresentação da solução</a></li>
