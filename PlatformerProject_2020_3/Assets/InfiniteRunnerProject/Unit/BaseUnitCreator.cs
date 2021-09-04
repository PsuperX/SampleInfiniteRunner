using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUnitCreator
    {
        protected Transform _parentTransform = null;
        protected UnitCreationSpec _creationSpec = null;

        public virtual Unit InstantiateUnit(UnitCreationSpec creationSpec)
        {
            Unit unit = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(creationSpec.unitType)) as Unit;
            unit.unitType = creationSpec.unitType;
            unit.gameObject.name += (" - " + creationSpec.unitType.ToString());

            unit.transform.localRotation = creationSpec.localRotation;
            unit.transform.localPosition = creationSpec.localPosition;

            return unit;
        }

        public virtual Unit DefineUnit()
        {
            return null;
        }

        public abstract void AddUnits(List<Unit> listUnits);
    }
}