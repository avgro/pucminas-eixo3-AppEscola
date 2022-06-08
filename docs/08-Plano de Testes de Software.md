
# Plano de Testes de Software
Os requisitos para realização dos testes de software são:

Antes da hospedagem da aplicação na internet.
- Visual Studio 2022 instalado e própriamente configurado na máquina da pessoa que vai realizar os testes;
- Clone do repositório do projeto;
- Navegador da internet - Chrome, Firefox ou Edge;

Após hospedagem da aplicação na internet.
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
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Cadastrar usuário" na tela inicial da conta de administrador 5) Preencher todas as informações requisitadas 6) Clicar no botão "Cadastrar". 7) O usuário será redirecionado para a tela de enviar e-mail com credenciais de acesso para o usuário, aonde deve clicar no botão "Enviar email". 8) O email contendo senha e usuário deverá ser enviado para o email do usuário recém cadastrado, na versão local da aplicação, este e-mail é enviado para a pasta local do sistema C:/AppEscolaMail em vez disso. 9) O usuário será redirecionado para a tela "Visualizar usuários cadastrados no sistema" onde o novo usuário cadastrado deverá estar presente na lista |
|Critérios de êxito| O novo usuário deve ser cadastrado com sucesso e aparecer na lista de usuários cadastrados do sistema. |

|Caso de teste 04     | CT 04 - Excluir conta de usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste|  Verificar se o sistema permite a exclusão de contas de usuário pelo administrador |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Realizar login com uma conta do tipo "Administrador" 4) Clicar na opção "Todos os usuários" na tela inicial da conta de administrador 5) Localizar o usuário que deseja deletar na lista de usuários cadastrados 6) Clicar no botão "Apagar". 7) Na tela seguinte, confirmar que deseja deletar o usuário em questão. 8) A tela de "Visualizar usuários" será atualizada e o usuário excluído deverá ter sumido dela |
|Critérios de êxito| O novo usuário deletado deve desaparecer da lista de usuários do sistema. |

|Caso de teste 05     | CT 05 -  Cadastrar turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de cadastrar novas turmas no sistema está funcionando adequadamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Turma" 5) Clicar na opção "Cadastrar turma" 6) Inserir nome da turma que deseja cadastar 7) Clicar em "Salvar". 8) Clicar em "Gerenciar associações" e verificar se a turma aparece disponível na lista de turmas a escolher. |
|Critérios de êxito| A turma deve ser cadastrada com sucesso e poder ser selecionada e estar disponível no sistema. |

|Caso de teste 06     | CT 06 -  Apagar turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de apagar turmas cadastradas no sistema está funcionando adequadamente.  |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar Turma" 5) Clicar na opção "Apagar Turma" 6) Selecionar nome da turma que deseja apagar 7) Clicar em "Apagar". 8) Clicar em "Gerenciar associações" e verificar se a turma desapareceu da lista de turmas a escolher. |
|Critérios de êxito| A turma deve ser apagada com sucesso e poder ser selecionada e não estar mais disponível no sistema. |

|Caso de teste 07     | CT 07 -  Cadastrar disciplina e associar disciplina a professor e turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-04 A aplicação deve permitir que o administrador do sistema associe um ou mais professores para cada disciplina cadastrada com um código distinto, sendo que disciplinas com o mesmo conteúdo podem ter códigos distintos em casos de múltiplas turmas com professores diferentes para cada uma.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma<br> |
|Objetivo do teste| Verificar se o a funcionalidade de cadastrar novas disciplinas no sistema está funcionando corretamente e se a mesma permite vincular a disciplina a um professor e uma turma |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Cadastrar disciplina" 6) Inserir o nome da disciplina e selecionar o professor responsável e a turma a qual a disciplina faz parte. 7) Clicar em "Salvar" 8) Caso uma turma tenha sido selecionada, o usuário será redirecionado para o quadro de turmas da disciplina aonde a disciplina deverá constar caso seus horários sejam compatíveis com as demais disciplinas 9) Caso ocorra conflito de horário, a disciplina será cadastrada no sistema, mas não será associada a nenhuma turma, uma mensagem de erro informando sobre o conflito de horários deverá aparecer no quadro de disciplinas da turma. |
|Critérios de êxito| A disciplina deve ser cadastrada com sucesso e ficar associada a um professor e turma. |

|Caso de teste 08     | CT 08 -  Editar disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-04 A aplicação deve permitir que o administrador do sistema associe um ou mais professores para cada disciplina cadastrada com um código distinto, sendo que disciplinas com o mesmo conteúdo podem ter códigos distintos em casos de múltiplas turmas com professores diferentes para cada uma.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma |
|Objetivo do teste| Verificar se a funcionalidade de editar disciplinas cadastradas no sistema está funcionando corretamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Editar disciplina" 6) Selecionar a disciplina que deseja alterar e inserir as novas informações da disciplina. 7) Clicar em "Salvar" 8) Caso uma turma tenha sido selecionada, o usuário será redirecionado para o quadro de turmas da disciplina aonde a disciplina deverá constar caso seus horários sejam compatíveis com as demais disciplinas 9) Caso ocorra conflito de horário, a disciplina será cadastrada no sistema, mas não será associada a nenhuma turma, uma mensagem de erro informando sobre o conflito de horários deverá aparecer no quadro de disciplinas da turma. |
|Critérios de êxito| A disciplina deve ser editada com sucesso e as novas informações devem aparecer no sistema. |

|Caso de teste 09     | CT 09 -  Apagar disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.<br>RF-04 A aplicação deve permitir que o administrador do sistema associe um ou mais professores para cada disciplina cadastrada com um código distinto, sendo que disciplinas com o mesmo conteúdo podem ter códigos distintos em casos de múltiplas turmas com professores diferentes para cada uma.<br>RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma |
|Objetivo do teste| Verificar se a funcionalidade de apagar disciplinas cadastradas no sistema está funcionando corretamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na aba "Cadastrar disciplina" 5) Selecionar a opção "Apagar disciplina" 6) Selecionar a disciplina que deseja apagar. 7) Clicar em "Apagar" 8) Clicar em "Gerenciar turmas" e clicar no botão "Ver quadro de disciplinas" da turma a qual a disciplina fazia parte. 9) Verificar se a disciplina apagada foi removida do quadro de horário da turma em questão. |
|Critérios de êxito| A disciplina deve ser apagada com sucesso e suas informações devem desaparecer do sistema. |

|Caso de teste 10     | CT 10 -  Cadastrar aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de cadastrar alunos no sistema esta funcionando adequadamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Cadastrar novo aluno" 5) Inserir as informações solicitadas no formulário 6) Clicar em "Cadastrar". 7) O usuário deve ser redirecionado para a tela de "Visualizar alunos cadastrados". O novo aluno cadastrado deve estar presente na lista |
|Critérios de êxito| O novo aluno deve ser cadastrado com sucesso e aparecer na lista de alunos cadastrados |

|Caso de teste 11     | CT 11 -  Editar informações do aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de editar informações dos alunos cadastrados no sistema esta funcionando adequadamente |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Editar" ao lado do nome do aluno 6) Inserir novas informações e clicar em "Salvar". 7) A tela de "Visualizar alunos cadastrados" será atualizada e o aluno selecionado deve ter desaparecido da lista |
|Critérios de êxito| As informações do aluno devem ser atualizadas e aparecer na lista de alunos cadastrados|

|Caso de teste 12     | CT 12 -  Excluir aluno |
|-------|-------------------------
|Requisitos Associados | 	 RF-03 A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste| Verificar se a funcionalidade de excluir alunos cadastrados no sistema esta funcionando adequadamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Cadastrar Aluno" 5) Na tela de "Visualizar alunos cadastrados", clicar na opção "Editar" ao lado do nome do aluno 6) A tela de "Visualizar alunos cadastrados" será atualizada e as informações do aluno selecionado devem ter sido atualizadas |
|Critérios de êxito|  O aluno deve ser deletado e desaparecer da lista de alunos cadastrados |

|Caso de teste 13     | CT 13 -  Trocar aluno de turma |
|-------|-------------------------
|Requisitos Associados | 	 RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma. | 
|Objetivo do teste| Verificar se o administrador do sistema consegue adicionar alunos a uma turma cadastrada. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como administrador 4) Clicar na opção "Gerenciar alunos" 5) Localizar o aluno que deseja trocar de turma e clicar na opção "Editar" 6) No campo "Selecionar turma", escolher a nova turma do aluno 7) Clicar em "Atualizar" e verificar se o aluno encontra-se cadastrado na nova turma clicando na opção "Mais informações" do aluno. 8) Clicar na opção "Gerenciar turmas" e escolher a opção "Mais informações" para verificar se o aluno aparece também na lista de alunos daquela turma. |
|Critérios de êxito| O aluno deve ser inserido na turma e deve aparecer listado entre os alunos pertencentes a turma. |

|Caso de teste 14     | CT 14 - Alterar Dados do usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-06  A aplicação deve permitir que usuários acessem suas contas, alterem suas informações de contato, endereço e senha.
|Objetivo do teste| Verificar se o usuário consegue acessar sua conta e alterar seus dados. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como qualquer tipo de usuário 4) Clicar no botão "Perfil" no canto direito do cabeçalho. 5) Escolher a opção "Alterar dados". 6) Inserir as novas informações no formulário. 7) Clicar no botão "Salvar". 8) Abrir novamente a página de "Alterar dados" e verificar se os dados foram atualizados.  |
|Critérios de êxito| Os dados do usuário devem ser alterados com sucesso e aparecer no sistema. |


|Caso de teste 15     | CT 15 - Realizar troca de mensagens e documentos |
|-------|-------------------------
|Requisitos Associados | 	 RF-07 - A aplicação deve permitir a troca de mensagens online pelo aplicativo entre os responsáveis do aluno e os professores, além de outros contatos relevantes como funcionários da secretaria e setor financeiro.<br>RF- 08 - A aplicação deve permitir envio de documentos, fotos, vídeos, autorizações para eventos e passeios (que podem ser aceitos dentro do próprio aplicativo).
|Objetivo do teste| Verificar a funcionalidade de troca de mensagens, documentos, fotos e vídeos. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema como qualquer tipo de usuário. 4) Clicar na aba "Mensagens". 5) Digitar  o assunto e conteúdo mensagem, anexar imagens e documentos. 6) Selecionar destinatários. 7) Clicar em enviar. 8) Fazer logoff e logar com a conta do usuário para o qual a mensagem foi enviada. 9) Verificar se mensagem chegou ao usuário selecionado  |
|Critérios de êxito| Mensagem deve ser enviada corretamente . Mensagem deve ser recebida pelo destinatário, constando remetente, arquivos e/ou documentos |

|Caso de teste 16     | CT 16 - Buscar Mensagens |
|-------|-------------------------
|Requisitos Associados | 	 RF-09  A aplicação deve apresentar uma função de pesquisa dentro do histórico de mensagens do usuário. A busca poderá ser feita por palavras chaves ou por nome de usuário.
|Objetivo do teste| Verificar se o site faz a busca por mensagens dentro do caixa de mensagens. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema como qualquer tipo de usuário. 4) Clicar na aba "Mensagens". 5) Digitar na caixa de busca o assunto da mensagem e clicar no botão de busca. 6) Visualizar mensagem procurada.  |
|Critérios de êxito| Localizar a mensagem desejada dentro da caixa de mensagens a partir das palavras chave inseridas. |

|Caso de teste 17     | CT 17 - Cadastrar eventos na agenda escolar |
|-------|-------------------------
|Requisitos Associados | 	 RF-10 - A aplicação deve apresentar uma agenda online que exiba para cada turma os eventos associados à rotina escolar do aluno (horário das aulas, provas, excursões e evento). Exibir também eventos associados a compromissos dos responsáveis do aluno (reunião de pais e professores).<br>RF-11-  A aplicação deve permitir aos professores adicionar eventos à agenda escolar de uma ou mais turmas, como: provas, excursões e reuniões que ficarão visíveis para os responsáveis do aluno daquela turma.|
|Objetivo do teste| Verificar se os usuários do tipo administrador e professor conseguem adicionar eventos à agenda.
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema como admnistrador ou professor. 4) Clicar na aba "Agenda". 5) Clicar em "Cadastrar evento". 6) Preencher informações solicitadas. 6) Clicar em "Salvar". 7) A tela de "Agenda escolar" deve ser atualizada e o novo evento cadastrado deve aparecer nela 8) Repetir o mesmo procedimento para todos os usuários capazes de cadastrar eventos na agenda |
|Critérios de êxito| O sistema deve registrar o evento cadastrado e carregar as atualizações feitas corretamente. |

|Caso de teste 18     | CT 18 - Visualizar eventos cadastrados na agenda escolar |
|-------|-------------------------
|Requisitos Associados | 	 RF-10 - A aplicação deve apresentar uma agenda online que exiba para cada turma os eventos associados à rotina escolar do aluno (horário das aulas, provas, excursões e evento). Exibir também eventos associados a compromissos dos responsáveis do aluno (reunião de pais e professores).<br>RF-11-  A aplicação deve permitir aos professores adicionar eventos à agenda escolar de uma ou mais turmas, como: provas, excursões e reuniões que ficarão visíveis para os responsáveis do aluno daquela turma.|
|Objetivo do teste| Verificar se todos os usuários conseguem visualizar os eventos cadastrados na agenda escolar.
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema como qualquer tipo de usuário. 4) Clicar na aba "Agenda". 5) Visualizar agenda escolar e seus eventos 6) Repetir o mesmo procedimento para todos os tipos de usuário. |
|Critérios de êxito| Evento estar disponível na agenda para todos os tipos de usuário visualizarem. |

|Caso de teste 19     | CT 19 - Apagar evento na agenda escolar |
|-------|-------------------------
|Requisitos Associados | 	 RF-10 - A aplicação deve apresentar uma agenda online que exiba para cada turma os eventos associados à rotina escolar do aluno (horário das aulas, provas, excursões e evento). Exibir também eventos associados a compromissos dos responsáveis do aluno (reunião de pais e professores).<br>RF-11-  A aplicação deve permitir aos professores adicionar eventos à agenda escolar de uma ou mais turmas, como: provas, excursões e reuniões que ficarão visíveis para os responsáveis do aluno daquela turma.|
|Objetivo do teste|  Verificar se os usuários do tipo administrador e professor conseguem remover eventos da agenda escolar.
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema como admnistrador ou professor. 4) Clicar na aba "Agenda". 5) Clicar em "Apagar evento". 6) Selecionar evento que se deseja apagar. 7) Clicar em "Apagar". 8) A tela de "Agenda escolar" deve ser atualizada e o evento apagado deve ter desaparecido da agenda 8) Repetir o mesmo procedimento para todos os usuários capazes de apagar eventos na agenda |
|Critérios de êxito| O evento selecionado deve ter sido apagado e o sistema deve carregar as atualizações feitas corretamente, de modo que o evento não apareça mais na agenda. |

|Caso de teste 20     | CT 20 - Assinar autorização para participação do filho em evento |
|-------|-------------------------
|Requisitos Associados | 	 RF-10 - A aplicação deve apresentar uma agenda online que exiba para cada turma os eventos associados à rotina escolar do aluno (horário das aulas, provas, excursões e evento). Exibir também eventos associados a compromissos dos responsáveis do aluno (reunião de pais e professores).<br>RF-11-  A aplicação deve permitir aos professores adicionar eventos à agenda escolar de uma ou mais turmas, como: provas, excursões e reuniões que ficarão visíveis para os responsáveis do aluno daquela turma.|
|Objetivo do teste| Verificar se o usuário do tipo "responsável do aluno" consegue autorizar o filho a participar de um evento que requer permissão |
|Passos |	1) Cadastrar um evento que requer autorização dos responsáveis na agenda escolar (seguindo os passos do CT-18 e marcando a opção "Requer autorização".	2) Fazer login como usuário do tipo "Responsável do aluno" que esteja associado a um aluno de uma turma que pode participar do evento 3) Informar o endereço do site. 4) Clicar na aba "Assinar autorização". 5) Selecionar autorização do evento em questão. 6) Clicar na opção "Autorizo meu/minha filho(a) a participar da atividade proposta acima". 6) Clicar em "Enviar". 7) A tela de "Assinar autorização" deve ser atualizada e a autorização em questão deve constar como assinada. 8) Repetir os mesmos passos, mas dessa vez negando a autorização ao aluno clicando em "Não autorizo meu/minha filho(a) a participar da atividade proposta acima" no passo 6 |
|Critérios de êxito| A autorização deve ser assinada com sucesso e constar como "assinada" ou "recusada" após o fim do processo a depender da escolha do usuário. |

|Caso de teste 21    | CT 21 - Adicionar evento na Linha do Tempo |
|-------|-------------------------
|Requisitos Associados | 	 RF-12 - A aplicação deve disponibilizar uma “linha do tempo” privada onde o professor possa fazer postagens, com fotos e texto sobre o aluno, que estarão visíveis apenas para os responsáveis daquele aluno, administradores do sistema e o respectivo professor.<br>A aplicação deve permitir envio de documentos, fotos, vídeos e autorizações para eventos e passeios (que podem ser aceitos dentro do próprio aplicativo) para os responsáveis do aluno pelos funcionários da escola |
|Objetivo do teste| Verificar se o usuário do tipo "professor" consegue postar um evento na linha do tempo de um aluno |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como usuário do tipo "Professor" 4) Clicar na aba "Linha do Tempo". 5) Clicar em "Cadastrar publicação". 6) Preencher as informações solicitadas. 7) Clicar em "Salvar" 8) A tela de "Linha do tempo" será atualizada e a nova postagem deverá aparecer nela . |
|Critérios de êxito| O professor deve ser capaz de cadastrar uma publicação que deve aparecer na linha do tempo após o cadastro. |

|Caso de teste 22    | CT 22 - Visualizar Linha do Tempo |
|-------|-------------------------
|Requisitos Associados | 	 RF-12 - A aplicação deve disponibilizar uma “linha do tempo” privada onde o professor possa fazer postagens, com fotos e texto sobre o aluno, que estarão visíveis apenas para os responsáveis daquele aluno, administradores do sistema e o respectivo professor.<br>A aplicação deve permitir envio de documentos, fotos, vídeos e autorizações para eventos e passeios (que podem ser aceitos dentro do próprio aplicativo) para os responsáveis do aluno pelos funcionários da escola |
|Objetivo do teste| Verificar se o usuário do tipo "responsável do aluno" consegue visualizar a linha do tempo do filho |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como usuário do tipo "Professor" 4) Clicar na aba "Linha do Tempo". 5) Visualizar publicação |
|Critérios de êxito| O responsável do aluno deve ser capaz de visualizar a publicação cadastrada pelo professor. |

|Caso de teste 23    | CT 23 - Comentar publicação da Linha do Tempo |
|-------|-------------------------
|Requisitos Associados | 	 RF-12 - A aplicação deve disponibilizar uma “linha do tempo” privada onde o professor possa fazer postagens, com fotos e texto sobre o aluno, que estarão visíveis apenas para os responsáveis daquele aluno, administradores do sistema e o respectivo professor.<br>A aplicação deve permitir envio de documentos, fotos, vídeos e autorizações para eventos e passeios (que podem ser aceitos dentro do próprio aplicativo) para os responsáveis do aluno pelos funcionários da escola |
|Objetivo do teste| Verificar se os usuários do tipo "Professor" e "Responsável do Aluno" conseguem comentar nas publicações da linha do tempo |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login como usuário do tipo "Professor" 4) Clicar na aba "Linha do Tempo". 5) Visualizar publicação 6) Escrever comentário na caixa de mensagem abaixo da publicação 7) Clicar em "Postar" 8) A tela de "Linha do tempo" deverá ser atualizada e o comentário estar presente na publicação 9) Repetir o mesmo procedimento com todos os tipos de usuário capazes de acessar a linha do tempo (Professor e responsável do aluno) |
|Critérios de êxito| O usuário deve postar um comentário na linha do tempo com sucesso e esse deve permanecer associado ao evento da linha do tempo ao visualizar a página. |

|Caso de teste 24     | CT 24 -  Lançar notificação no sistema |
|-------|-------------------------
|Requisitos Associados | 	 RF-13 - A aplicação deve possuir uma seção de notificações onde o usuário responsável será notificado sobre eventos, mensagens importantes e compromissos cuja data esteja próxima.
|Objetivo do teste| Verificar se o usuário do tipo "Administrador" consegue lançar notificações no sistema |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login com usuário do tipo "Administrador". 4) Clicar em "Notificações". 5) Clicar em "criar notificação" 6) Preencher os dados solicitados no formulário. 7) Clicar em "Lançar notificação". 8) Clicar novamente em "Notificações" e verificar se a notificação está presente |
|Critérios de êxito| A notificação deve ser lançado com sucesso no sistema e aparecer na tela "Notificações". |

|Caso de teste 25     | CT 25 -  Visualizar Notificações |
|-------|-------------------------
|Requisitos Associados | 	 RF-13 - A aplicação deve possuir uma seção de notificações onde o usuário responsável será notificado sobre eventos, mensagens importantes e compromissos cuja data esteja próxima.
|Objetivo do teste| Verificar se a carga de notificações está acontecendo corretamente. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Fazer login no sistema. 4) Clicar em notificações. 5) Visualizar área de notificações.  |
|Critérios de êxito| As notificações devem ser exibidas corretamente para o usuário. |

|Caso de teste 26     | CT 26 - Testar responsividade do sistema em diferentes dispositivos |
|-------|-------------------------
|Requisitos Associados | 	 RNF-02 - O site deverá ser responsivo permitindo a visualização em um celular de forma adequada.
|Objetivo do teste| Verificar a responsividade do site. |
|Passos |	1) Acessar o navegador de um computador.	2) Informar o endereço do site. 3) Visualizar a página principal. 4) Navegar por todas as telas do site e verificar responsividade do layout. 5) Acessar o site de um dispositivo móvel. 6) Informar o endereço do site. 7) Visualizar a página principal. 8) Navegar por todas as telas do site e verificar responsividade do layout. |
|Critérios de êxito| O site deve ser totalmente responsivo, sem quebras de texto e páginas em nenhum dispositivo utilizado. |











