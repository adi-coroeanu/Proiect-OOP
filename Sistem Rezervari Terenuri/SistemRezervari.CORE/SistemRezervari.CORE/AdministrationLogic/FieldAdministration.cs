using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class FieldAdministration : IFieldAdministration
{

    private List<Teren> _fields;
    private FieldRepository _fieldRepository;

    public FieldAdministration(FieldRepository fieldRepository)
    {
        _fieldRepository = fieldRepository;
        _fields = _fieldRepository.GetCopyAll();
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
        foreach (var field in _fields)
        {
            if (field.Id == terenId)
            {
                var newfield = field with
                {
                    Nume = newFieldName,
                    TipSport = newFieldType,
                    Capacitate = newFieldCapacity,
                    intervale_indisponibile = newFieldRestrictions,
                    program_de_functionare = newFieldProgram
                };
                break;
            }
        }
    }

    #endregion

    #region Public Methods

        public void AddField(string name, string type, int capacity, string program)
        {
            _AddField(name, type, capacity, program);
            _fieldRepository.ModifyList(_fields);
        }


        public void RemoveField(Guid fieldId)
        {
            _RemoveField(fieldId);
            _fieldRepository.ModifyList(_fields);
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
            _fieldRepository.ModifyList(_fields);
        }


        #endregion
    }
