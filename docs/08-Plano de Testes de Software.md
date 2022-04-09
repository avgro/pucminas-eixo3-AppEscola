
# Plano de Testes de Software
Os requisitos para realização dos testes de software são:
- Site publicado na internet;
- Navegador da internet - Chrome, Firefox ou Edge;
- Conectividade de internet para acesso às plataformas.

Por meio desse plano de testes serão verificados e validados os requisitos para garantir o bom funcionamento do programa junto ao usuário final. Nosso plano de teste de software tem como foco garantir a confiabilidade e segurança, identificando possíveis erros e falhas durante a sua confecção, ou mesmo depois.
 
### Casos de Testes
Os testes funcionais a serem realizados no aplicativo são descritos a seguir:

|Caso de teste 01     | CT 01 - Autenticação e Login |
|-------|-------------------------
|Requisitos Associados | 	 RF-01  A aplicação deve possuir um sistema de autenticação e login com quatro tipos de usuários: administrador do sistema, responsáveis pelo aluno, professor e o funcionário (tipo genérico que abrange membros da secretaria, setor financeiro etc.).
|Objetivo do teste| Verificar a funcionalidade de autenticidade e de login do sistema. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Visualizar a página principal. 4) Clicar no botão "Login" presente no canto direito do cabeçalho. 5) Informar nome de usuário e senha cadastrados no sistema para um determinado usuário. 6) Clicar no botão "Entrar". |
|Critérios de êxito| O sistema será direcionado para a tela Home Page personalizada . |

|Caso de teste 02     | CT 02 - Visualizar usuários cadastrados no sistema |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste|  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis. Verificar se o usuário cadastrado recebeu o e-mail após a criação da conta pelo administrador.|
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Todos os usuários" na tela inicial da conta de administrador 5) Visualizar usuários listados na tela|
|Critérios de êxito| ● O usuário deverá ser direcionado para a tela de "visualizar todos os usuários do sistema" e ser capaz de ver os usuários cadastrados. |


|Caso de teste 03     | CT 03 - Criar e Excluir Conta Usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste|  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis. Verificar se o usuário cadastrado recebeu o e-mail após a criação da conta pelo administrador.|
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Cadastrar usuário" na tela inicial da conta de administrador 5) Preencher todas as informações requisitadas 6) Clicar no botão "Cadastrar". 7) O usuário será redirecionado para a tela "Visualizar usuários cadastrados no sistema" onde o novo usuário cadastrado deverá estar presente na lista |
|Critérios de êxito| ● O novo usuário deve ser cadastrado com sucesso e aparecer na lista de usuários cadastrados do sistema. |

|Caso de teste 03     | CT 03 - Associar Professor/ Disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-04 A aplicação deve permitir que o administrador do sistema associe um ou mais professores para cada disciplina cadastrada com um código distinto, sendo que disciplinas com o mesmo conteúdo podem ter códigos distintos em casos de múltiplas turmas com professores diferentes para cada uma. .
|Objetivo do teste| Verificar se o administrador do sistema consegue associar os professores as disciplinas cadastradas. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha do administrador. Informar usuário e senha. 4) Associar o professor a sua respectiva disciplina. 5) Salvar. |
|Critérios de êxito| O professor deve estar associado à sua disciplina corretamente. |

|Caso de teste 04     | CT 04 -  Adicionar ou Remover Aluno/ Disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma.
|Objetivo do teste| Verificar se o administrador do sistema consegue adicionar ou excluir os alunos às disciplinas cadastradas. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. 4) Clicar no botão adicionar e ou remover aluno/ disciplina. 5) Salvar. |
|Critérios de êxito| O aluno deve estar associado à sua disciplina corretamente. |

|Caso de teste 05     | CT 05 - Alterar Dados |
|-------|-------------------------
|Requisitos Associados | 	 RF-06  A aplicação deve permitir que usuários acessem suas contas, alterem suas informações de contato, endereço e senha.
|Objetivo do teste| Verificar se o usuário consegue acessar sua conta e alterar seus dados. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Alterar informações do contato. 5) Clicar no botão Salvar alterações.  |
|Critérios de êxito| Os dados do usuário devem ser alterados com sucesso. . |


|Caso de teste 06     | CT 06 - Troca de Mensagens e Documentos |
|-------|-------------------------
|Requisitos Associados | 	 RF-07 - A aplicação deve permitir a troca de mensagens online pelo aplicativo entre os responsáveis do aluno e os professores, além de outros contatos relevantes como funcionários da secretaria e setor financeiro. RF- 08 - A aplicação deve permitir envio de documentos, fotos, vídeos, autorizações para eventos e passeios (que podem ser aceitos dentro do próprio aplicativo). .
|Objetivo do teste| Verificar as trocas de mensagens, documentos, fotos e vídeos. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Acessar área de mensagens. 5) Digitar  mensagem. 6) Escolher destinatário. 7) Clicar em enviar.  |
|Critérios de êxito| Mensagem deve ser enviada corretamente . Mensagem deve ser recebida corretamente constando remetente, arquivos e/ou documentos |

|Caso de teste 07     | CT 07 - Buscar Mensagens |
|-------|-------------------------
|Requisitos Associados | 	 RF-09  A aplicação deve apresentar uma função de pesquisa dentro do histórico de mensagens do usuário. A busca poderá ser feita por palavras chaves ou por nome de usuário.
|Objetivo do teste| Verificar se o site faz a busca por mensagens dentro do histórico.. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Acessar área de mensagens. 5) Clicar na mensagem que queira visualizar. |
|Critérios de êxito| Site localiza dentro do seu banco de dados mensagens com as palavras chaves buscadas . |


|Caso de teste 08     | CT 08 - Visualizar e Alterar Agenda online |
|-------|-------------------------
|Requisitos Associados | 	 RF-10 - A aplicação deve apresentar uma agenda online que exiba para cada turma os eventos associados à rotina escolar do aluno (horário das aulas, provas, excursões e evento). Exibir também eventos associados a compromissos dos responsáveis do aluno (reunião de pais e professores). RF-11-  A aplicação deve permitir aos professores adicionar eventos à agenda escolar de uma ou mais turmas, como: provas, excursões e reuniões que ficarão visíveis para os responsáveis do aluno daquela turma.
|Objetivo do teste| - Verificar e o usuário professor consegue adicionar eventos à agenda. - Verificar se o usuário responsável pelo aluno consegue visualizar a agenda e suas atualizações feitas pelo usuário professor na turma correta. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha do professor ou administrador. 4) Clicar em  agenda escolar. 5) Alterar agenda escolar. 6) Salvar. |
|Critérios de êxito| O sistema deve carregar as atualizações feitas corretamente. |

|Caso de teste 09    | CT 09 - Visualizar Linha do Tempo |
|-------|-------------------------
|Requisitos Associados | 	 RF-12 - A aplicação deve disponibilizar uma “linha do tempo” privada onde o professor possa fazer postagens, com fotos e texto sobre o aluno, que estarão visíveis apenas para os responsáveis daquele aluno, administradores do sistema e o respectivo professor.
|Objetivo do teste| Verificar se a linha do tempo está sendo apresentada completamente na página. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Clicar em linha do tempo. 5) Visualizar linha do tempo. |
|Critérios de êxito| Apresentação das postagens com fotos e texto visíveis para seus respectivos responsáveis. |

|Caso de teste 10     | CT 10 -  Visualizar Notificações |
|-------|-------------------------
|Requisitos Associados | 	 RF-13 - A aplicação deve possuir uma seção de notificações onde o usuário responsável será notificado sobre eventos, mensagens importantes e compromissos cuja data esteja próxima.
|Objetivo do teste| Verificar se a carga de notificações está acontecendo corretamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Clicar em notificações. 5) Visualizar área de notificações.  |
|Critérios de êxito| As notificações devem ser exibidas corretamente. |











