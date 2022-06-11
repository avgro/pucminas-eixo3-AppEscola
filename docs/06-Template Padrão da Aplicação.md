# Template Padrão da Aplicação

O layout padrão que será utilizado na aplicação segue o modelo mostrado na seção <a href="04-Projeto%20de%20Interface.md"> Projeto de Interface</a>, sendo que todas as páginas da aplicação apresentam as mesmas seções "header" e "footer", que acabam assim definindo a maior parte da identidade visual da aplicação. A seção "Conteúdo da página" presente nas figuras desta seção demarca o conteúdo variável presente entre estas duas seções fixas, que muda de acordo com a seção do site que está sendo visualizada. 
<br>

Após a realização do login pelo usuário, a maior parte das telas visitadas apresentará também um menu lateral de navegação (localizado à esquerda do conteúdo da página), que permitirá a navegação entre as diversas seções correspondentes a cada funcionalidades disponível para o usuário (caixa de mensagens, agenda escolar, etc). Outra mudança que ocorre após o login é a substituição do botão de login presente no header por um botão com a mensagem "Olá, "Nome do Usuário" ", que pode ser clicado para abrir um menu dropdown contendo opções relativas a conta do usuário. 
<br>

A nível de código, este layout é implementado no arquivo <a href="../src/App-comunicacao-escolar/Views/Shared/_Layout.cshtml">_Layout.cshtml</a>, que contém o código para a apresentação do header, footer e menu lateral (além da função que controla quando ele deverá ser exibido) e uma seção contendo a função *@RenderBody()*, que é responsável por renderizar o conteúdo da página apresentado de acordo com a seção em que o usuário se encontra dentro da aplicação.
<br>

O projeto utiliza o Bootstrap em conjunto com media queries customizadas no CSS para a responsividade.
<br>

Nas figuras abaixo, segue o layout padrão conforme será exibido dentro da aplicação: 

## Tela principal (Desktop)
![template_nao_logado](https://user-images.githubusercontent.com/74699119/173170738-23216990-b020-4c6c-9666-97f6807eb303.png)
<p align="center"><b>Figura 9</b> - Template da tela principal da aplicação em tamanho Desktop</p>
<br>

## Tela principal (Mobile)
### Opções do header escondidas
![template_mobile](https://user-images.githubusercontent.com/74699119/168379968-52234657-925a-47aa-a90f-52a0d6c8dae9.png)

<p align="center"><b>Figura 10</b> - Template da tela principal da aplicação em tamanho Mobile, com as opções presentes no header colapsadas</p>

### Opções do header a mostra
![template_mobile_toggle](https://user-images.githubusercontent.com/74699119/168379972-040ef1d8-5b2a-4602-818a-f40c2064854c.png)

<p align="center"><b>Figura 11</b> - Template da tela principal da aplicação em tamanho Mobile, com as opções presentes no header sendo exibidas após clicar no icone "Toggle" presente no header</p>

## Tela principal com menu lateral (Desktop)
![template_logado](https://user-images.githubusercontent.com/74699119/173170726-cbbe4b66-1e83-4b0f-ba06-b860f7aafe3a.png)

<p align="center"><b>Figura 12</b> - Template da tela principal da aplicação em tamanho Desktop com menu lateral de navegação presente</p>

## Tela principal com menu lateral (Desktop, largura < 1200 px)
![template_logado1199px](https://user-images.githubusercontent.com/74699119/173170728-5770dd54-24bd-4a98-b5de-fff97beec52b.png)

<p align="center"><b>Figura 13</b> - Template da tela principal da aplicação com largura da janela do navegador menor que 1200 pixels, com menu lateral de navegação presente</p>

## Tela principal com menu lateral (Mobile)
### Opções do header escondidas
![template_mobile_hiddenheader](https://user-images.githubusercontent.com/74699119/173170729-01e1cebf-8feb-4dcb-90be-fbb5cb43c374.png)

<p align="center"><b>Figura 14</b> - Template da tela principal da aplicação em tamanho Mobile com menu lateral de navegação presente e com as opções presentes no header colapsadas</p>

### Opções do header a mostra
![template_mobile_showheader](https://user-images.githubusercontent.com/74699119/173170730-171a0ff0-f396-4471-8748-b5572d0c1660.png)

<p align="center"><b>Figura 15</b> - Template da tela principal da aplicação em tamanho Mobile com menu lateral de navegação presente e com as opções presentes no header sendo exibidas após clicar no icone "Toggle" presente no header</p>

## Menu dropdown de opções da conta do usuário
![template_opcoes_usuario](https://user-images.githubusercontent.com/74699119/168380528-adf9e908-675b-4d3d-836a-fbb4654d64c2.png)

<p align="center"><b>Figura 16</b> - Menu dropdown contendo as opções da conta do usuário. Acessado clicando em "Olá, "Nome do usuário" " no canto direito do header após o login</p>
