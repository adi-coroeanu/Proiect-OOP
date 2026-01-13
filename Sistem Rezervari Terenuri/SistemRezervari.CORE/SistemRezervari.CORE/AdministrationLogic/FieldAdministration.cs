using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class FieldAdministration : IFieldAdministration
{

    private List<Teren> _fields;
    private IFileRepository _fileRepository;
    private List<Utilizator> _users;

    public FieldAdministration(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
        _fields = _fileRepository.IncarcaTerenuri();
        _users = _fileRepository.IncarcaUtilizatori();
    }

    #region Private Methods

    private void _AddField(string name, string type, int capacity, string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard)
    {
        bool ok = true;
        string pattern = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]-([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
        List<string> interv = intervale_indisponibile.Split(",",StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
        if(!Regex.IsMatch(program, pattern))
            throw new Exception("Open from/to error: The format must be HH:mm-HH:mm (ex: 08:00-22:00).");
        foreach (string intervale in interv)
        {//11:00-12:00
            if (intervale.ToLower() == "none") 
                continue;
            if (!Regex.IsMatch(intervale, pattern))
            {
                ok = false;
                throw new Exception("Closed intervals error: One or more intervals have an invalid format or are not separated by comma.");
            }
        }
        
        if(ok)
            _fields.Add(new Teren(Guid.NewGuid(), name, type, capacity, program,intervale_indisponibile,nr_max_rezervari,durata_standard));
        
    }

    private void _RemoveField(Guid fieldId)
    {
        for (int i = 0; i < _fields.Count; i++)
        {
            if (_fields[i].Id == fieldId)
                _fields.RemoveAt(i);
        }
    }

    private Teren _GetFieldById(Guid fieldId)
    {
        return _fields.FirstOrDefault(x => x.Id == fieldId);
    }



    private void _ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity,
        string newFieldProgram, string newFieldRestrictions,int _nr_max_rezervari, int _durata_standard)
    {
        bool ok = true;
        string pattern_newFieldProgram = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]-([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
        List<string> programs = newFieldRestrictions.Split(",",StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
        if (Regex.IsMatch(newFieldProgram, pattern_newFieldProgram))    
        {
            foreach (string program in programs)
            {
                if (program.ToLower() == "none") 
                    continue;
                if (!Regex.IsMatch(program, pattern_newFieldProgram))
                {
                    throw new Exception("Closed intervals error: One or more intervals have an invalid format or are not separated by comma.");
                }
            }

            if(ok)
                    for (int i = 0; i < _fields.Count; i++)
                    {
                        if (_fields[i].Id == terenId)
                        {
                            var newfield = _fields[i] with
                            {
                                Nume = newFieldName,
                                TipSport = newFieldType,
                                Capacitate = newFieldCapacity,
                                intervale_indisponibile = newFieldRestrictions,
                                program_de_functionare = newFieldProgram,
                                nr_max_rezervari = _nr_max_rezervari,
                                durata_standard = _durata_standard
                            };
                            _fields[i] = newfield;
                            break;
                        }
                    }
            
               
        }
        else
        {
            throw new Exception("Open from/to error: The format must be HH:mm-HH:mm (ex: 08:00-22:00).");
        }
       
    }


    private Utilizator _GetUserById(Guid userId)
    {
        return _users.FirstOrDefault(x => x.Id == userId);
    }
    #endregion

    #region Public Methods

        public void AddField(string name, string type, int capacity, string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard)
        {
            _fields = _fileRepository.IncarcaTerenuri();
            _AddField(name, type, capacity, program ,intervale_indisponibile,nr_max_rezervari, durata_standard);
            _fileRepository.SalveazaTerenuri(_fields);
        }


        public void RemoveField(Guid fieldId)
        {
            _fields = _fileRepository.IncarcaTerenuri();
            _RemoveField(fieldId);
            _fileRepository.SalveazaTerenuri(_fields);
        }

        public Teren GetFieldById(Guid terenId)
        {
            _fields = _fileRepository.IncarcaTerenuri();
            return _GetFieldById(terenId);
        }

        public List<Teren> GetAllFields()
        {
            _fields = _fileRepository.IncarcaTerenuri();
            return _fields;
        }


        public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity,
            string newFieldProgram, string newFieldRestrictions,int nr_max_rezervari, int durata_standard)
        {
            _fields = _fileRepository.IncarcaTerenuri();
            _ModifyField(terenId,  newFieldName,  newFieldType, newFieldCapacity, newFieldProgram, newFieldRestrictions,nr_max_rezervari, durata_standard);
            _fileRepository.SalveazaTerenuri(_fields);
        }

        public Utilizator GetUserById(Guid userId)
        {
            return _GetUserById(userId);
        }

        #endregion
    }
