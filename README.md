# API de Cálculo de Valor da Corrida

Esta API calcula o valor de uma corrida com base em parâmetros como distância, tempo e valor por quilômetro e por minuto. Além disso, o valor final da corrida é ajustado por um multiplicador, dependendo da plataforma utilizada (Uber, 99pop, ou Taxi).

## Fórmula para Cálculo do Valor da Corrida

A fórmula usada para calcular o valor final da corrida é a seguinte:

**ValorCorrida** = (PrecoBase + (Distancia * ValorPorKm) + (Tempo * ValorPorMinuto)) * MultiplicadorPlataforma

Onde:

- **PrecoBase**: Valor fixo inicial da corrida.
- **Distancia**: Distância percorrida na corrida (em quilômetros).
- **ValorPorKm**: Valor cobrado por quilômetro rodado.
- **Tempo**: Tempo de corrida (em minutos).
- **ValorPorMinuto**: Valor cobrado por minuto de corrida.
- **MultiplicadorPlataforma**: Multiplicador definido pela plataforma (ex: Uber, 99pop, taxi).

## Exemplo de Cálculo

Vamos supor os seguintes valores:

- **PrecoBase** = 10.0 (valor fixo para começar a corrida)
- **Distancia** = 5.0 km
- **Tempo** = 15.0 minutos
- **ValorPorKm** = 2.0
- **ValorPorMinuto** = 0.5
- **Plataforma** = "uber" (Multiplicador = 1.5)

Agora, vamos calcular o valor da corrida com esses valores:

1. **Cálculo do Custo da Distância**:  
   Distância = 5.0 km, Valor por Km = 2.0  
   \[
   \{Custo da Distância} = 5.0 \times 2.0 = 10.0
   \]

2. **Cálculo do Custo do Tempo**:  
   Tempo = 15.0 minutos, Valor por Minuto = 0.5  
   \[
   \{Custo do Tempo} = 15.0 \times 0.5 = 7.5
   \]

3. **Valor Total Antes do Multiplicador**:  
   Somando o **PrecoBase** com o **Custo da Distância** e o **Custo do Tempo**:
   \[
   \{Valor Total Inicial} = 10.0 + 10.0 + 7.5 = 27.5
   \]

4. **Aplicando o Multiplicador da Plataforma**:  
   Multiplicador para Uber = 1.5  
   \[
   \{Valor Corrida Final} = 27.5 \times 1.5 = 41.25
   \]

Portanto, o **ValorCorrida Final** será **41.25**.

## Como Usar a API

Para utilizar a API, envie uma requisição `POST` para o endpoint `/api/calcularPreco/valorCorrida` com um corpo de requisição no formato JSON.

### Exemplo de JSON para a Requisição

```json
{
  "precoBase": 10.0,
  "distancia": 5.0,
  "tempo": 15.0,
  "valorPorKm": 2.0,
  "valorPorMinuto": 0.5,
  "valorPlataforma": "uber"
}
