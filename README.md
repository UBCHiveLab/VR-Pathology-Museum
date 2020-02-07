# VR-Pathology-Museum
Learning pathology in VR


> This GitHub repo is set up using Git LFS. Please install **Git LFS** before pulling from GitHub.
>
> Refer to [Git Large File Storage](https://git-lfs.github.com/) for more information about Git LFS.

Unity Version: **2019.1.14f1**

This project reads in 3D models through premade unity asset bundles. 

There are two projects contains in the repository.

Pathology Museum VR Project folder contains the actual VR projects.

Model Labling Project folder contains the project that can be used for importing 3D models.

> For more information about how to import 3D models, create asset bundle and make labels on the 3D model, please refer to following documentation:
> [Anatomy VR Models](https://docs.google.com/document/d/1G_IU1hgOp9C2bEYy1sqjhqgxUIwwteYiZ0EY4QPzujk/edit#heading=h.41wqmwj69tnh)

Right now the asset bundle is hosted on a local server, in order to run the project properly, user/developer should clone following repository:
[AssetBundleServer](https://github.com/UBCHiveLab/AssetBundleServer)


After cloning the asset bundle server, do following actions to run the server:

1. navigate to the folder of the server through CMD or PowerShell.

2. run server by running command 

3. Run node server.js

4. The localhost can be access through address 127.0.0.1:10070.

5. Local host address and port can be adjust by adjusting env.js file.

