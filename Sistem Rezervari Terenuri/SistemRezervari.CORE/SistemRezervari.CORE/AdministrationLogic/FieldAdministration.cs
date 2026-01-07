using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Data;
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

    private void _AddField(string name, string type, int capacity, string program)
    {
        _fields.Add(new Teren(Guid.NewGuid(), name, type, capacity, program, ""));
        
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
        string newFieldProgram, string newFieldRestrictions)
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
                                program_de_functionare = newFieldProgram
                            };
                            _fields[i] = newfield;
                            break;
                        }
                    }
                else
                {
                    //aici intra logica de ILogger eventual
                }
        }
        else
        {
            //aici iar logica ILogger
        }
    }

    #endregion

    #region Public Methods

        public void AddField(string name, string type, int capacity, string program)
        {
            _AddField(name, type, capacity, program);
            _fileRepository.SalveazaTerenuri(_fields);
        }


        public void RemoveField(Guid fieldId)
        {
            _RemoveField(fieldId);
            _fileRepository.SalveazaTerenuri(_fields);
        }

        public Teren GetFieldById(Guid terenId)
        {
            return _GetFieldById(terenId);
        }

        public List<Teren> GetAllFields()
        {
            return _fields;
        }


        public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity,
            string newFieldProgram, string newFieldRestrictions)
        {
            _ModifyField(terenId,  newFieldName,  newFieldType, newFieldCapacity, newFieldProgram, newFieldRestrictions);
            _fileRepository.SalveazaTerenuri(_fields);
        }


        #endregion
    }
