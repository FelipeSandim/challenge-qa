Relatírios de Bugs

Bug 01:
**Tratamento da opção "Selecione um curso"**
Passos para reproduzir:
1. Acesse a página de cadastro
2. Clique no menu de selecionar curso de Pós-graduação
**Resultado atual:** Quando o usuário acessa a página inicial de cadastro abre o menu para selecionar tipo de curso em que ele quer se cadastrar, no menu ja vem aparecendo por padrtão a opção "Graduação".
**Resultado esperado:** Quando o usuário acessa a página inicial de cadastro abre o menu para selecionar tipo de curso em que ele quer se cadastrar, no menu por padrão deve aparecer por default a opção "Selecione um curso", deixando apenas como uma instrução de onde o usuário deve interagir, ode depois de selecionar o curso o usuário não podera selecionar a opção "Selecione um curso" novamente deixando essa opção como inativa.

Bug 02:
**Cursos de Pós-Graduação aparecendo na lista de graduação**
Passos para reproduzir:
1. Acesse a página de cadastro
2. Selecione o nivel de ensino
3. Abra o menu de cursos
**Resultado Atual:** Quando o usuário entra na página de cadastro e seleciona o nivel de ensino "Graduação" e é direcionado para a pagina de seleção de cursos, ele abre o menu de cursos e ali são listados os cursos em que ele pode se instcrever, nisso contendo os cursos de pós-graduação em meio aos cursos de graduação.
**Resultado esperado:**Quando o usuário entra na página de cadastro e seleciona o nivel de ensino "Graduação" e é direcionado para a pagina de seleção de cursos, ele abre o menu de cursos e ali são listados os cursos em que ele pode se instcrever, contendo somente os cursos relacionados a graduação, e mantendo tambem a lista de pós-graduação trarada para que não apareça os cursos de graduaçãoi.

Bug 03:
**Campos CPF, Celular, Telefone, e CEP sem Tratamento de Caracteres**
Passos para Reproduzir:
1. Acesse a página de cadastro
2. Selecione o nivel de ensino
3. Selecione o Curso
**Resultado Atual:** Após o usuário selecionat o tipo de graduação e o curso que quer fazer, ele é direcionado para uma página onde ele preenchera com seus dados para sua inscrição no curso desejado, quando ele preenche os campos CPF, Celular, Telefone, e CEP, ele consegue preencher esses campos com letras e caracteres especiais em meio aos numeros, sem limite de caracteres.
**Resultado esperado:** Após o usuário selecionat o tipo de graduação e o curso que quer fazer, ele é direcionado para uma página onde ele preenchera com seus dados para sua inscrição no curso desejado, quando ele preenche os campos CPF, Celular, Telefone, e CEP, ele só consegue preencher os campos informando numeros com o limite que cada informação pede, EX:
CPF: 999.999.999-99
Celular: (99) 99999-9999
Telefone: (99) 99999-9999
CEP: 999999-999

Bug 04:
**Campos CEP sem Validação**
Passos para Reproduzir:
1. Acesse a página de cadastro
2. Selecione o nivel de ensino
3. Selecione o Curso
**Resultado Atual:** Após o usuário selecionat o tipo de graduação e o curso que quer fazer, ele é direcionado para uma página onde ele preenchera com seus dados para sua inscrição no curso desejado, apos o preenchimento de um CEP inexistente o sistema permite ele avançar para a conclusão de sua inscrição.
**Resultado Esperado:** Após o usuário selecionat o tipo de graduação e o curso que quer fazer, ele é direcionado para uma página onde ele preenchera com seus dados para sua inscrição no curso desejado, apos o preenchimento de um CEP inexistente o sistema deve informar uma mensagem de alerta logo abaixo do campo informando "CEP Inválido".

Bug 05:
**Campos Login e Senha com Mensagem de Erro**
Passos para Reproduzir:
1. Acesse a página de cadastro
2. Selecione o nivel de ensino
3. Selecione o Curso
4. Preencha a Ficha de Cadastro
5. Avance para a Tela de Login
**Resultado Atual:** Após o usuário concluir seu cadastro com sucesso ele será direcionado para a página de login, onde ele deverá preencher som seu usuário e senha, logo que o usuário começa a digitar seus dados uma mensagem de alerta "Usuário inválido" e "Senha Inválida".
**Resultado Esperado:** Após o usuário concluir seu cadastro com sucesso ele será direcionado para a página de login, onde ele deverá preencher som seu usuário e senha, lapós o usuário digitar seus dados de login e selecionar no botão login, caso algum dos dados forem inválidos então devera aparecer a mensagem "Usuário inválido" ou "Senha Inválida".

