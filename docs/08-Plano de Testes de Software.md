
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
|Objetivo do teste| Verificar a funcionalidade de autenticação e de login do sistema. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Visualizar a página principal. 4) Clicar no botão "Login" presente no canto direito do cabeçalho. 5) Informar nome de usuário e senha cadastrados no sistema para um determinado usuário. 6) Clicar no botão "Entrar". |
|Critérios de êxito| O sistema será direcionado para a tela Home Page personalizada . |

|Caso de teste 02     | CT 02 - Visualizar usuários cadastrados no sistema |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se o sistema permite visualizar os usuários cadastrados no sistema |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Todos os usuários" na tela inicial da conta de administrador 5) Visualizar usuários listados na tela|
|Critérios de êxito| O usuário deverá ser direcionado para a tela de "visualizar todos os usuários do sistema" e ser capaz de ver os usuários cadastrados. |


|Caso de teste 03     | CT 03 - Criar conta de usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se o sistema de realizar cadastro de usuário pelo administrador está funcionando corretamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Todos os usuários" na tela inicial da conta de administrador 5) Localizar o usuário que deseja deletar na lista de usuários cadastrados 6) Clicar no botão "Deletar". 7) A tela de "Visualizar usuários" será atualizada e o usuário excluído deverá ter sumido dela |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Cadastrar usuário" na tela inicial da conta de administrador 5) Preencher todas as informações requisitadas 6) Clicar no botão "Cadastrar". 7) O usuário será redirecionado para a tela "Visualizar usuários cadastrados no sistema" onde o novo usuário cadastrado deverá estar presente na lista |
|Critérios de êxito| O novo usuário deve ser cadastrado com sucesso e aparecer na lista de usuários cadastrados do sistema. |

|Caso de teste 04     | CT 04 - Excluir conta de usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste|  Verificar se o sistema permite a exclusão de contas de usuário pelo administrador |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Todos os usuários" na tela inicial da conta de administrador 5) Localizar o usuário que deseja deletar na lista de usuários cadastrados 6) Clicar no botão "Deletar". 7) A tela de "Visualizar usuários" será atualizada e o usuário excluído deverá ter sumido dela |
|Critérios de êxito| O novo usuário deletado deve desaparecer da lista de usuários do sistema. |

|Caso de teste 05     | CT 05 -  Cadastrar aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de cadastrar alunos no sistema esta funcionando adequadamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Cadastrar novo aluno" 5) Inserir as informações solicitadas no formulário 6) Clicar em "Cadastrar". 7) O usuário deve ser redirecionado para a tela de "Visualizar alunos cadastrados". O novo aluno cadastrado deve estar presente na lista |
|Critérios de êxito| O novo aluno deve ser cadastrado com sucesso e aparecer na lista de alunos cadastrados |

|Caso de teste 06     | CT 06 -  Editar informações do aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de editar informações dos alunos cadastrados no sistema esta funcionando adequadamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Editar" ao lado do nome do aluno 6) Inserir novas informações e clicar em "Salvar". 7) A tela de "Visualizar alunos cadastrados" será atualizada e o aluno selecionado deve ter desaparecido da lista |
|Critérios de êxito| O aluno deve ser deletado e desaparecer da lista de alunos cadastrados |

|Caso de teste 07     | CT 07 -  Excluir aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de excluir alunos cadastrados no sistema esta funcionando adequadamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Editar" ao lado do nome do aluno 6) A tela de "Visualizar alunos cadastrados" será atualizada e as informações do aluno selecionado devem ter sido atualizadas |
|Critérios de êxito| As informações do aluno devem ser atualizadas e aparecer na lista de alunos cadastrados |


|Caso de teste 08     | CT 08 -  Cadastrar turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de cadastrar novas turmas no sistema está funcionando adequadamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Turma" 5) Clicar na opção "Cadastrar turma" 6) Inserir nome da turma que deseja cadastar 7) Clicar em "Salvar". 8) Clicar em "Gerenciar associações" e verificar se a turma aparece disponível na lista de turmas a escolher. |
|Critérios de êxito| A turma deve ser cadastrada com sucesso e poder ser selecionada e estar disponível no sistema. |

|Caso de teste 09     | CT 09 -  Apagar turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de apagar turmas cadastradas no sistema está funcionando adequadamente.  |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar Turma" 5) Clicar na opção "Apagar Turma" 6) Selecionar nome da turma que deseja apagar 7) Clicar em "Apagar". 8) Clicar em "Gerenciar associações" e verificar se a turma desapareceu da lista de turmas a escolher. |
|Critérios de êxito| A turma deve ser apagada com sucesso e poder ser selecionada e não estar mais disponível no sistema. |

|Caso de teste 10     | CT 10 -  Cadastrar disciplina e associar disciplina a professor e turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma |
|Objetivo do teste| Verificar se o a funcionalidade de cadastrar novas disciplinas no sistema está funcionando corretamente e se a mesma permite vincular a disciplina a um professor e uma turma |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Cadastrar disciplina" 6) Inserir o nome da disciplina e selecionar o professor responsável e a turma a qual a disciplina faz parte. 7) Clicar em "Salvar" 8) Clicar em "Gerenciar associações" e verificar se a disciplina aparece listada para a turma em questão |
|Critérios de êxito| A disciplina deve ser cadastrada com sucesso e ficar associada a um professor e turma. |

|Caso de teste 11     | CT 11 -  Editar disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma |
|Objetivo do teste| Verificar se o a funcionalidade de editar disciplinas cadastradas no sistema está funcionando corretamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Editar disciplina" 6) Selecionar a disciplina que deseja alterar e inserir as novas informações da disciplina. 7) Clicar em "Salvar" 8) Clicar em "Gerenciar associações" e verificar se a disciplina aparece listada com os novos dados. |
|Critérios de êxito| A disciplina deve ser editada com sucesso e as novas informações devem aparecer no sistema. |

|Caso de teste 12     | CT 12 -  Apagar disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma |
|Objetivo do teste| Verificar se o a funcionalidade de editar disciplinas cadastradas no sistema está funcionando corretamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Apagar disciplina" 6) Selecionar a disciplina que deseja apagar. 7) Clicar em "Apagar" 8) Clicar em "Gerenciar associações" e verificar se a disciplina aparece listada com os novos dados. |
|Critérios de êxito| A disciplina deve ser apagada com sucesso e suas informações devem desaparecer do sistema. |

|Caso de teste 13     | CT 13 -  Adicionar Aluno a uma turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis. | 
|Objetivo do teste| Verificar se o administrador do sistema consegue adicionar alunos a uma turma cadastrada. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Associar alunos à turma" 5) Selecionar nome da turma que deseja apagar 6) Selecionar o nome do aluno que deseja incluir na turma. 7) Clicar em "Salvar" e verificar se a turma desapareceu da lista de turmas a escolher. 8) Clicar em "Gerenciar associações" e verificar se o aluno aparece listado na turma. |
|Critérios de êxito| O aluno deve ser inserido na turma e deve aparecer listado entre os alunos pertencentes a turma. |

|Caso de teste 14     | CT 14 -  Remover aluno de uma turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis. | 
|Objetivo do teste| Verificar se o administrador do sistema consegue remover alunos de uma turma cadastrada. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Gerenciar associações" 5) Selecionar nome da turma que deseja retirar o aluno 6) Procurar o nome do aluno na lista e clicar em "Apagar" 8) A tela de "Gerenciar associações" será atualizada e o aluno apagado deverá estar ausente da lista de alunos da turma. |
|Critérios de êxito| O aluno deve ser removido da turma e não deve mais aparecer listado entre os alunos pertencentes a turma. |

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











