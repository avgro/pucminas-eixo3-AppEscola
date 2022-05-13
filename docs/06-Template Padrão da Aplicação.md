# Template Padrão da Aplicação

O layout padrão que será utilizado no site segue o modelo mostrado na seçaõ Projeto de Interface, sendo que todas as páginas compartilham o mesmo "header" e "footer", sendo o conteúdo presente entre eles variável de acordo com a seção do site que está sendo visualizada. Após a realização do login pelo usuário, a maior parte das telas visitadas apresentará também um menu lateral de navegação à esquerda que permitirá a navegação entre as diversas seções correspondentes a cada funcionalidades disponível para o usuário (caixa de mensagens, agenda escolar, etc).

## Tela principal (Desktop)
![template_desktop](https://user-images.githubusercontent.com/74699119/168379726-bec9bec6-5aea-4478-98b9-fe054e50a9ca.png)

## Tela principal (Mobile)
### Opções do header escondidas
![template_mobile](https://user-images.githubusercontent.com/74699119/168379968-52234657-925a-47aa-a90f-52a0d6c8dae9.png)
### Opções do header a mostra
![template_mobile_toggle](https://user-images.githubusercontent.com/74699119/168379972-040ef1d8-5b2a-4602-818a-f40c2064854c.png)

## Tela principal com menu lateral (Desktop)
![template_menu_desktop](https://user-images.githubusercontent.com/74699119/168380271-e773d24a-0602-4719-8762-3752def1bdae.png)

## Tela principal com menu lateral (Desktop, largura < 1200 px)
![template_menu_1199px](https://user-images.githubusercontent.com/74699119/168380306-ed1ea3f1-2fd0-4843-add2-1741ef91e169.png)

## Tela principal com menu lateral (Mobile)
### Opções do header escondidas
![template_menu_mobile](https://user-images.githubusercontent.com/74699119/168380418-bdf3fe54-791e-4512-bf2a-b317d9299be3.png)
### Opções do header a mostra
![template_menu_mobile_toggle](https://user-images.githubusercontent.com/74699119/168380358-d2f13727-448f-4360-a42e-3ebac4f5b58b.png)

## Menu do usuário (acessado clicando em "Olá, Usuário" no canto direito do header após o login)
![template_opcoes_usuario](https://user-images.githubusercontent.com/74699119/168380528-adf9e908-675b-4d3d-836a-fbb4654d64c2.png)

O projeto utiliza o Bootstrap em conjunto com media queries customizadas no CSS para a responsividade, sendo a classe "container" do Bootstrap aplicada ao conteúdo central da página.
