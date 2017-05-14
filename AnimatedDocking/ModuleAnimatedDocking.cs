using System;

using KSP;

namespace AnimatedDocking
{
    public class ModuleAnimatedDocking : PartModule
    {
        private ModuleAnimateGeneric module;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            this.module = base.part.FindModuleImplementing<ModuleAnimateGeneric>();
            if (this.module == null) return;
            GameEvents.onPartCouple.Add(this.onPartCouple);
            GameEvents.onPartUndock.Add(this.onPartUndock);
        }
        private void onPartCouple(GameEvents.FromToAction<Part, Part> action)
        {
            if (action.from == base.part)
            {
                module.Toggle();
            }
        }
        private void onPartUndock(Part part)
        {
            if (part = base.part)
            {
                module.Toggle();
            }
        }
        private void OnDestroy()
        {
            GameEvents.onPartCouple.Add(this.onPartCouple);
            GameEvents.onPartUndock.Remove(this.onPartUndock);
        }
    }
}
