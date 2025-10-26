using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            AutoMappingRequest();
            AutoMappingResponse();
        }

        private void AutoMappingRequest()
        {
            CreateMap<InvoiceRequest, Invoice>();

        }

        private void AutoMappingResponse()
        {
            CreateMap<Invoice, InvoiceResponse>();
            CreateMap<Invoice, InvoiceShortResponse>();
        }
    }
}
