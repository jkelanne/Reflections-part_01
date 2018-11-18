using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;
using System.Linq;

public static class Injector {

    // Simple static injector
    public static void InjectProperty<T>(GameObject gameObject, T dependency) {
        // Go through the child objects
        foreach(Transform child in gameObject.transform) { 
            foreach(Component childComponent in child.gameObject.GetComponents<Component>()) {
                // Using the power of LIQN to get the settable properties for the Components where we can read and write the value and is of type T
                var properties = childComponent.GetType().GetProperties().Where(prop => prop.CanRead && prop.CanWrite).Where(prop => prop.PropertyType == typeof(T));

                // If nothing of suitable type is foundt, properties variable should be null
                if(properties != null) {
                    foreach(PropertyInfo pi in properties) {
                        // Use SetValue of System.Reflection.PropertyInfo to set the value of the property
                        pi.SetValue(childComponent, (object)dependency, null);
                    }
                }
            }
        }
    }
}
