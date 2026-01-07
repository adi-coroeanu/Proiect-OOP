using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class FieldAdministration : IFieldAdministration
{

    private List<Teren> _fields;
    private IFileRepository _fileRepository;
    

    public FieldAdministration(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
        _fields = _fileRepository.IncarcaTerenuri();
    }

    #region Private Methods

    private void _AddField(string name, string type, int capacity, string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard)
    {
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
                if (!Regex.IsMatch(program, pattern_newFieldProgram))
                {
                    ok = false;
                    break;
                }
                    
                    if(ok==true)
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


        #endregion
    }
