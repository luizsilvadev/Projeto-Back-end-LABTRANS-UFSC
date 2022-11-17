using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceBooking : IServiceBooking
    {
        private readonly IBooking _IBooking;

        public ServiceBooking(IBooking IBooking)
        {
            _IBooking = IBooking;
        }

        public async Task Adicionar(Booking Objeto)
        {
            var validarLocal = Objeto.ValidarPropriedadeString(Objeto.Local.ToString(), "Local");
            var validarSala = Objeto.ValidarPropriedadeString(Objeto.Sala.ToString(), "Sala");
            var validarDataHoraInicio = Objeto.ValidarPropriedadeDateTime(Objeto.DataHoraInicio, "DataHoraInicio");
            var validarDataHoraFim = Objeto.ValidarPropriedadeDateTime(Objeto.DataHoraFim, "DataHoraFim");
            var validarResponsavel = Objeto.ValidarPropriedadeString(Objeto.Responsavel, "Responsavel");
            var validarQtdPessoasCafe = true;
            if (Objeto.Cafe)
            {
                validarQtdPessoasCafe = Objeto.ValidarPropriedadeInt(Objeto.QtdPessoasCafe, "DataHoraFim");
            }

            if (validarLocal && validarSala && validarDataHoraInicio && validarDataHoraFim && validarResponsavel && validarQtdPessoasCafe)
            {
                var horarioDisponivel = PesquisarHorarioDisponivel(_IBooking, Objeto.DataHoraInicio, Objeto.DataHoraFim, Objeto.Sala, Objeto.Local, Objeto.Id);
                var validarHoraioDisponivel = Objeto.ValidarHoraioDisponivel(horarioDisponivel, "DataHoraInicio,DataHoraFim");
                if (validarHoraioDisponivel)
                { 
                    await _IBooking.Add(Objeto);
                }
            }
        }

        public async Task Atualizar(Booking Objeto)
        {
            var validarLocal = Objeto.ValidarPropriedadeString(Objeto.Local.ToString(), "Local");
            var validarSala = Objeto.ValidarPropriedadeString(Objeto.Sala.ToString(), "Sala");
            var validarDataHoraInicio = Objeto.ValidarPropriedadeDateTime(Objeto.DataHoraInicio, "DataHoraInicio");
            var validarDataHoraFim = Objeto.ValidarPropriedadeDateTime(Objeto.DataHoraFim, "DataHoraFim");
            var validarResponsavel = Objeto.ValidarPropriedadeString(Objeto.Responsavel, "Responsavel");
            var validarQtdPessoasCafe = true;
            if (Objeto.Cafe)
            {
                validarQtdPessoasCafe = Objeto.ValidarPropriedadeInt(Objeto.QtdPessoasCafe, "QtdPessoasCafe");
            }

            if (validarLocal && validarSala && validarDataHoraInicio && validarDataHoraFim && validarResponsavel && validarQtdPessoasCafe)
            {
                var temHorarioDisponivel = PesquisarHorarioDisponivel(_IBooking, Objeto.DataHoraInicio, Objeto.DataHoraFim, Objeto.Sala, Objeto.Local, Objeto.Id);
                var validarHoraioDisponivel = Objeto.ValidarHoraioDisponivel(temHorarioDisponivel, "DataHoraInicio/Fim");
                if (validarHoraioDisponivel)
                {
                    await _IBooking.Update(Objeto);
                }
            }
        }

        /* logica por trás da regra de negócio sobre horários de agendamento
        
 	    di1                                                        df1
 	     |----------------------------------------------------------|   colidindo
                 |------------------------------|                       
                di2                            df2
        
 					        di1                    df1
  					         |----------------------|                   colidindo
  		 |----------------------------------------------------------|   
 		di2                                                        df2  

        di1                                   df1
         |-------------------------------------|                        colidindo
                                     |------------------------------|   
                                    di2                            df2

 					        di1                                    df1  
  					        |---------------------------------------|   colidindo
         |-----------------------------------|                          
        di2                                 df2

 					        		        di1                    df1  
 						        	         |----------------------|   não colidindo
         |------------------------------|                               
        di2                            df2
        
 		di1                    df1
  		 |----------------------|                                       não colidindo
  						             |------------------------------|   
 						            di2                            df2
        
        if (( di2 <= di1 && di1 <= df2 ) || ( di2 <= df1 && df1 <= df2 ) || ( di1 <= di2 && df2 <= df1 )) {
	        return 'Horario invalido';
        }
        
        if (!( di2 <= di1 && df2 <= di1 ) || !( di2 >= di1 && df2 >= di1 )) {
	        return 'Horario invalido';
        }
        
        partindo do pressuposto de que a data inicial é sempre menor que a final temos
        
        if (!( df2 <= di1 || di2 >= df1 )) {
	        return 'Horario invalido';
        }
        */

        static bool PesquisarHorarioDisponivel(IBooking Objeto, DateTime dti, DateTime dtf, Sala sala, Local local, int id)
        {
            if (dtf <= dti) return false; // hora final não pode ser maior que hora inicial

            var horarioDisponivel = Objeto.ListarBooking(n => !(n.DataHoraFim <= dti || n.DataHoraInicio >= dtf) && n.Sala == sala && n.Local == local).Result;

            if (horarioDisponivel.Count() == 0)
            {
                return true; // se não encontrar nenhum horario dentro do intervalo das outras reservas é verdadeiro
            }
            if (horarioDisponivel.Count() == 1 && horarioDisponivel[0].Id == id)
            {
                return true; // se for uma alteração é verdadeiro
            }
            return false;
        }

        //public async Task<List<Booking>> ListarBookingCafe()
        //{
        //    return await _IBooking.ListarBooking(n => n.Cafe);
        //}
    }
}
