﻿using DesingPatterns.Application.Strategy.Calculador.Interface;
using DesingPatterns.Application.Strategy.Model.Imposto.ICMS;
using DesingPatterns.Application.Strategy.Repositories;
using DesingPatterns.Domain.Strategy.Constante;
using DesingPatterns.Domain.Strategy.Imposto;

namespace DesingPatterns.Application.Strategy.Calculador
{
    public class Calculador : ICalculador
    {
        private readonly ITaxaImpostoRepository _taxaImpostoRepository;

        public Calculador(ITaxaImpostoRepository taxaImpostoRepository)
        {
            _taxaImpostoRepository = taxaImpostoRepository;
        }

        public Task<CalculadorDeImposto> IdentificaImposto(ObterImpostoDeduzidoRequest request)
        {
            IImposto imposto;
            switch (request.imposto)
            {
                case ImpostoTipo.Icms:
                    imposto = new ICMS(_taxaImpostoRepository);
                    return imposto.Calcular(request);
                
                case ImpostoTipo.Iss:
                    imposto = new ISS(_taxaImpostoRepository);
                    return imposto.Calcular(request);
            }

            return null;
        }
    }
}
