
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
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Visualizar a página principal. |
|Critérios de êxito| O sistema será direcionado para a tela Home Page . |

|Caso de teste 02     | CT 02 - Criar e Excluir Conta Usuário |
|-------|-------------------------
|Requisitos Associados | 	 RF-02 A aplicação deve oferecer ao administrador do sistema a funcionalidade de criar contas de usuário para responsáveis do aluno, professores e outros funcionários, enviando as informações de login através de e-mail para eles após a criação. RF-03  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis.
|Objetivo do teste|  A aplicação deve permitir ao administrador do sistema cadastrar ou deletar professores, disciplinas e turmas, além de alunos e seus respectivos responsáveis. Verificar se o usuário cadastrado recebeu o e-mail após a criação da conta pelo administrador.|
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha  . 4) Acessar a área de cadastros para efetuar a inclusão ou a exclusão de usuário. 5) Clicar em " Salvar "|
|Critérios de êxito| ●O administrador deve conseguir cadastrar ou excluir corretamente uma conta de usuário. ●O usuário deve receber um e-mail, com informações de login, após o administrador criar a conta. |

|Caso de teste 03     | CT 03 - Associar Professor/ Disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-04 A aplicação deve permitir que o administrador do sistema associe um ou mais professores para cada disciplina cadastrada com um código distinto, sendo que disciplinas com o mesmo conteúdo podem ter códigos distintos em casos de múltiplas turmas com professores diferentes para cada uma. .
|Objetivo do teste| Verificar se o administrador do sistema consegue associar os professores as disciplinas cadastradas. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) |
|Critérios de êxito| O professor deve estar associado à sua disciplina corretamente. |

|Caso de teste 04     | CT 04 -  Adicionar ou Remover Aluno/ Disciplina |
|-------|-------------------------
|Requisitos Associados | 	 RF-05 A aplicação deve permitir que o administrador do sistema adicione ou remova alunos das turmas disponíveis, além de selecionar as disciplinas que serão ministradas para aquela turma.
|Objetivo do teste| Verificar se o administrador do sistema consegue adicionar ou excluir os alunos às disciplinas cadastradas. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. 4) Clicar no botão adicionar e ou remover aluno/ disciplina. |
|Critérios de êxito| O aluno deve estar associado à sua disciplina corretamente. |

|Caso de teste 05     | CT 05 - Alterar Dados |
|-------|-------------------------
|Requisitos Associados | 	 RF-06  A aplicação deve permitir que usuários acessem suas contas, alterem suas informações de contato, endereço e senha.
|Objetivo do teste| Verificar se o usuário consegue acessar sua conta e alterar seus dados. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha. 4) Alterar informações do contato. 5) Clicar no botão Salvar alterações.  |
|Critérios de êxito| Os dados do usuário devem ser alterados com sucesso. . |


|Caso de teste 06     | CT 06 - Troca de Mensagens e Documentos |
|-------|-------------------------
|Requisitos Associados | 	 RF-07 - A aplicação deve permitir a troca de mensagens online pelo aplicativo entre os responsáveis do aluno e os professores, além de outros contatos relevantes como funcionários da secretaria e setor financeiro. RF- 08 - A aplicação deve permitir envio de documentos, fotos, vídeos, autorizações para eventos e passeios (que podem ser aceito dentro do próprio aplicativo). .
|Objetivo do teste| Verificar as trocas de mensagens, documentos, fotos e vídeos. |
|Passos |	1) Acessar o navegador.	2) Informar o endereço do site. 3) Clicar botão usuário e senha. Informar usuário e senha.4) Acessar área de mensagens. |
|Critérios de êxito| Mensagem deve ser enviada corretamente . Mensagem deve ser recebida corretamente constando remetente, arquivos e/ou documentos |







