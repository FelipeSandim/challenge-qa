import http from 'k6/http';
import { sleep } from 'k6';
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js';

export const options = {
  vus: 100,
  duration: '30s',
};

export default function () {
  http.get('https://test.k6.io/my_messages.php');
  sleep(1);
}

// Gera o relatório HTML ao final do teste
export function handleSummary(data) {
  return {
    'relatorios/relatorio_messages.html': htmlReport(data),
  };
}
