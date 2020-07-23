// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.Editor
{
    public class ComponentIconRenderer : SchemaTypeVisualElement<global::Improbable.Gdk.Editor.ComponentIcon>
    {
        private readonly TextField iconNameField;

        public ComponentIconRenderer(string label) : base(label)
        {
            iconNameField = new TextField("Icon Name");
            iconNameField.SetEnabled(false);
            Container.Add(iconNameField);
        }

        public override void Update(global::Improbable.Gdk.Editor.ComponentIcon data)
        {
            iconNameField.value = data.IconName.ToString();
        }
    }
}
