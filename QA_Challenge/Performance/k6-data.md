# k6-data.md

## Estratégia de Massa de Dados para Testes com K6

### Simulação de Usuários
- Gerar usuários com IDs variados para simular uso simultâneo.
- Alternar parâmetros ou headers para garantir diversidade nos requests.

### Isolamento
- Não há escrita em banco, logo os testes podem ser paralelos sem conflito.

### Execução
- Para simular 100, 500 e 1000 usuários, utilizamos a configuração de `vus` no script:
  - `vus: 100`
  - `vus: 500`
  - `vus: 1000`

### Relatórios
- Gerar `.json` com `--summary-export`
- Usar `k6 report` para gerar HTML de forma clara e visual
