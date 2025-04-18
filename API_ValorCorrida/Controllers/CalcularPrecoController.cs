using Microsoft.AspNetCore.Mvc;

namespace API_ValorCorrida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularPrecoController : Controller
    {
        [HttpPost("valorCorrida")]
        public IActionResult CalcularValorCorrida([FromBody] RequisicaoCalculo dados)
        {
            try
            {
                //Obter multiplicador dependendo da plataforma feita na funcao abaixo
                double multiplicador = ObterMultiplicadorPlataforma(dados.ValorPlataforma);

                //Calcular valor da corrida
                double valorCorrida = (dados.PrecoBase + (dados.Distancia * dados.ValorPorKm) + (dados.Tempo * dados.ValorPorMinuto)) * multiplicador;

                return Ok(new { valorCorrida });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        //Funcao para verificar o tipo de plataforma e aplicar o multiplicador
        private double ObterMultiplicadorPlataforma(string plataforma)
        {
            double multiplicador = 2.0; // valor padrão caso não caia em nenhuma condição

            if (plataforma.ToLower() == "uber")
            {
                multiplicador = 1.5;
            }
            else if (plataforma.ToLower() == "99pop")
            {
                multiplicador = 1.2;
            }
            else if (plataforma.ToLower() == "taxi")
            {
                multiplicador = 1.6;
            }

            return multiplicador;
        }
    }

    public class RequisicaoCalculo
    {
        public double PrecoBase { get; set; }//Valo inicial da corrida
        public double Distancia { get; set; }//Distancia em km
        public double Tempo { get; set; }//Tempo em minutos
        public double ValorPorKm { get; set; }//Preco por km rodado
        public double ValorPorMinuto { get; set; }//Preco por min da corrida
        public string ValorPlataforma { get; set; }//Dependendo da plataforma vai voltar o valor com o multiplicador
    }
}
