Feature: Cadastro de Usuário

@Cadastro
Scenario: 01 - Cadastro com nível de ensino Graduação
  Given que o usuário acessa a página de cadastro
  When o usuário seleciona o nível de ensino "graduação"
  And o usuário seleciona o curso "Mestrado em Ciência da Computação"
  And o usuário clica no botão avançar
  And o usuário preenche o formulário de cadastro
  And o usuário clica no botão avançar
  And o usuário clica no botão avançar
  And o sistema faz login com usuário "candidato" e senha "subscription"
  Then o sistema deve exibir a mensagem "Bem-vindo, Candidato!" na tela inicial

@Cadastro
Scenario: 01 - Cadastro com nível de ensino Pós Graduação
  Given que o usuário acessa a página de cadastro
  When o usuário seleciona o nível de ensino "pós-graduação"
  And o usuário seleciona o curso "Mestrado em Ciência da Computação"
  And o usuário clica no botão avançar
  And o usuário preenche o formulário de cadastro
  And o usuário clica no botão avançar
  And o usuário clica no botão avançar
  And o sistema faz login com usuário "candidato" e senha "subscription"
  Then o sistema deve exibir a mensagem "Bem-vindo, Candidato!" na tela inicial

@LoginComUsuarioIncorreto
Scenario: Login com usuario incorreto
  Given que o usuário acessa a página de cadastro
  When o usuário seleciona o nível de ensino "graduação"
  And o usuário seleciona o curso "Mestrado em Ciência da Computação"
  And o usuário clica no botão avançar
  And o usuário preenche o formulário de cadastro
  And o usuário clica no botão avançar
  And o usuário clica no botão avançar
  And o sistema faz login com usuário "Teste" e senha "subscription"
  Then o sistema deve exibir a mensagem de erro de usuário "Usuário inválido"

@LoginComSenhaIncorreta
Scenario: Login com senha incorreta
  Given que o usuário acessa a página de cadastro
  When o usuário seleciona o nível de ensino "graduação"
  And o usuário seleciona o curso "Mestrado em Ciência da Computação"
  And o usuário clica no botão avançar
  And o usuário preenche o formulário de cadastro
  And o usuário clica no botão avançar
  And o usuário clica no botão avançar
  And o sistema faz login com usuário "candidato" e senha "Teste"
  Then o sistema deve exibir a mensagem de erro de senha "Senha inválida"

@ValidacaoCamposObrigatorios
Scenario: Validação de campos obrigatórios vazios
  Given que o usuário acessa a página de cadastro     
  When o usuário seleciona o nível de ensino "graduação"
  And o usuário seleciona o curso "Mestrado em Ciência da Computação"
  And o usuário clica no botão avançar
  And o usuário clica no botão avançar
  Then o sistema deve exibir as seguintes mensagens de erro:
    | mensagens           |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |
    | Campo obrigatório   |



