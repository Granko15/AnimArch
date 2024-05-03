using UnityEngine;
using System.IO;
using Visualisation.UI;
using System.Collections.Generic;

namespace Visualization.UI{
    public class PatternCatalogueCompositeLoader : MonoBehaviour
    {
        [SerializeField] private GameObject parent;
        public List<GameObject> patternPrefabs;
   
        public void Browse(PatternCatalogueComponent patternCatalogueComponent)
        {
            patternPrefabs = new List<GameObject>();

            string folderPath = "Assets/Resources/PatternCatalogue";

            if (Directory.Exists(folderPath)){
                RecursivelyListFiles(folderPath, patternCatalogueComponent, parent);
            }else{
                Debug.LogError("Folder does not exist: " + folderPath);
            }
        }

        void RecursivelyListFiles(string folderPath, PatternCatalogueComponent patternCatalogueComponent, GameObject parent)
        {   
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files){
                if(!file.Contains(".meta")){
                    GameObject leaf = GetComponent<PatternCatalogueLeafBuilder>().Build(patternCatalogueComponent, parent, file);
                    patternPrefabs.Add(leaf);
                }
            }

            string[] subFolders = Directory.GetDirectories(folderPath);
            foreach (string subFolder in subFolders){
                PatternCatalogueCompositeBuilder compositeBuilder = GetComponent<PatternCatalogueCompositeBuilder>();
                GameObject composite = compositeBuilder.Build(patternCatalogueComponent, parent, subFolder);
                GameObject newParent = composite;
                patternPrefabs.Add(composite);
                RecursivelyListFiles(subFolder, composite.GetComponent<PatternCatalogueComponent>(), newParent);
            }
        }
    }
}

