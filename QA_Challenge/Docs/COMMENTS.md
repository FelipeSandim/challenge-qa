# COMMENTS.md

## Decisões da Arquitetura
- Utilizei Reqnroll (SpecFlow) para definir os testes BDD com clareza e organização.
- A automação E2E foi estruturada utilizando o padrão Page Object Model, centralizando os seletores e interações em classes separadas.
- Dividi os testes por arquivos `.feature` para manter clareza e escalabilidade dos cenários.

## Bibliotecas Utilizadas
- Selenium WebDriver
- XUnit
- FluentAssertions
- Reqnroll

## Melhorias com mais tempo
- Executar os testes em múltiplos browsers com Selenium Grid
- Automatizar os testes de performance em pipeline CI/CD
- Adicionar testes negativos mais complexos (como CPF inválido, e-mail com domínio incorreto, etc.)

## Requisitos não entregues
- Integração com banco PostgreSQL (ainda não disponível na aplicação)
