[33mcommit a1a35f5e260aeaa0768724984c0261a6e10424d0[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 20:26:46 2017 +0100

    Fix OrganizationController

 src/dotnet-g23/Controllers/GroupController.cs       |  8 [32m++++[m[31m----[m
 src/dotnet-g23/Data/DataInitializer.cs              | 14 [32m+++++++++++[m[31m---[m
 src/dotnet-g23/Data/Repositories/GroupRepository.cs |  8 [32m++++[m[31m----[m
 src/dotnet-g23/Models/Domain/Organization.cs        |  3 [32m++[m[31m-[m
 4 files changed, 21 insertions(+), 12 deletions(-)

[33mcommit b0a6a00f5d80bd5c5870e832a0b351ccbab37b17[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 20:21:22 2017 +0100

    Remove cyclical FKs

 src/dotnet-g23/Data/ApplicationDbContext.cs        |  12 [32m+[m[31m-[m
 ...0311192034_RemoveCyclicalRequiredFK.Designer.cs | 448 [32m+++++++++++++++++++++[m
 .../20170311192034_RemoveCyclicalRequiredFK.cs     |  89 [32m++++[m
 .../ApplicationDbContextModelSnapshot.cs           |  12 [32m+[m[31m-[m
 4 files changed, 546 insertions(+), 15 deletions(-)

[33mcommit 7c11cc20256488981ad4e11d183a4659abc002ee[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 20:00:39 2017 +0100

    Database schema update for Invitation move

 ...oveInvitationsFromUserToParticipant.Designer.cs | 452 [32m+++++++++++++++++++++[m
 ...1185941_MoveInvitationsFromUserToParticipant.cs |  59 [32m+++[m
 .../ApplicationDbContextModelSnapshot.cs           |   8 [32m+[m[31m-[m
 3 files changed, 515 insertions(+), 4 deletions(-)

[33mcommit 22db754d637c2917d4349780820ccfe41bea6625[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 19:47:18 2017 +0100

    Translate remaining strings to Dutch

 src/dotnet-g23/Models/Domain/GUser.cs        | 2 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/Group.cs        | 4 [32m++[m[31m--[m
 src/dotnet-g23/Models/Domain/Motivation.cs   | 2 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/Organization.cs | 6 [32m+++[m[31m---[m
 4 files changed, 7 insertions(+), 7 deletions(-)

[33mcommit 45706b4d1229eab0dd4e5fa59c17c0f24c114b5c[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 19:45:46 2017 +0100

    Move GUser-Invitation to Participant-Invitation

 dotnet-g23.Tests/Controllers/OrganizationControllerTest.cs     |  8 [32m++++[m[31m----[m
 src/dotnet-g23/Controllers/GroupController.cs                  |  7 [32m+++[m[31m----[m
 src/dotnet-g23/Data/ApplicationDbContext.cs                    |  2 [32m+[m[31m-[m
 src/dotnet-g23/Data/Repositories/InvitationRepository.cs       | 10 [32m++++++[m[31m----[m
 src/dotnet-g23/Data/Repositories/ParticipantRepository.cs      |  3 [32m+++[m
 src/dotnet-g23/Models/Domain/GUser.cs                          |  2 [31m--[m
 src/dotnet-g23/Models/Domain/Group.cs                          | 10 [32m+++++[m[31m-----[m
 src/dotnet-g23/Models/Domain/Invitation.cs                     |  6 [32m+++[m[31m---[m
 src/dotnet-g23/Models/Domain/Participant.cs                    |  2 [32m++[m
 .../Models/Domain/Repositories/IInvitationRepository.cs        |  2 [32m+[m[31m-[m
 10 files changed, 28 insertions(+), 24 deletions(-)

[33mcommit 95861da3520405755fe0f15410d96ab6932d6861[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 19:42:26 2017 +0100

    Move GUser-Invitations to Participant-Invitations

 vpp/dotnet-g23.vpp | Bin [31m759808[m -> [32m759808[m bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

[33mcommit 2a9c68c893bcf0943c2352d068aade737e7789c2[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 17:26:20 2017 +0100

    Update class diagram with le nouveau schème du database

 vpp/dotnet-g23.vpp | Bin [31m759808[m -> [32m759808[m bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

[33mcommit 7b46bb16f44b0cb337f1275b45c6fc21fb4ed380[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 19:34:15 2017 +0100

    Fix organizations search

 src/dotnet-g23/Controllers/OrganizationController.cs       | 10 [32m++++[m[31m------[m
 src/dotnet-g23/Data/Repositories/OrganizationRepository.cs |  6 [32m++++[m[31m--[m
 src/dotnet-g23/Helpers/MailHelper.cs                       | 14 [31m--------------[m
 src/dotnet-g23/Models/Domain/GUser.cs                      |  8 [32m+++++++[m[31m-[m
 src/dotnet-g23/Models/Domain/Group.cs                      |  2 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/Organization.cs               |  3 [32m+[m[31m--[m
 .../Models/Domain/Repositories/IOrganizationRepository.cs  |  2 [32m+[m[31m-[m
 7 files changed, 18 insertions(+), 27 deletions(-)

[33mcommit d08b6a0df9014ccbab8696715dc8165e20d2b924[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 17:49:53 2017 +0100

    Show subscribed group

 src/dotnet-g23/Controllers/GroupController.cs                  |  2 [32m+[m[31m-[m
 src/dotnet-g23/Controllers/MotivationController.cs             |  2 [32m+[m[31m-[m
 src/dotnet-g23/Controllers/OrganizationController.cs           |  7 [32m++++[m[31m---[m
 src/dotnet-g23/Data/Repositories/GroupRepository.cs            | 10 [32m++++++[m[31m----[m
 src/dotnet-g23/Data/Repositories/ParticipantRepository.cs      |  7 [32m++++[m[31m---[m
 src/dotnet-g23/Filters/OrganizationFilter.cs                   |  2 [32m+[m[31m-[m
 src/dotnet-g23/Filters/ParticipantFilter.cs                    |  7 [32m++[m[31m-----[m
 src/dotnet-g23/Filters/UserFilter.cs                           |  7 [32m++++[m[31m---[m
 .../Models/Domain/Repositories/IParticipantRepository.cs       |  5 [32m+++[m[31m--[m
 9 files changed, 26 insertions(+), 23 deletions(-)

[33mcommit c197450b5e4e0b3b3ae559f350b4f9fa8aa260c3[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 17:19:41 2017 +0100

    Add volunteers and participants to DataInitializer

 src/dotnet-g23/Data/DataInitializer.cs | 169 [32m+++++++++++++++[m[31m------------------[m
 1 file changed, 74 insertions(+), 95 deletions(-)

[33mcommit afc4a2d12b17bab940cd744e1ed42d7c2867e970[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 16:43:17 2017 +0100

    Update domain associations

 src/dotnet-g23/Models/Domain/GUser.cs              | 18 [32m++++[m[31m------------[m
 src/dotnet-g23/Models/Domain/Group.cs              | 25 [32m++++++++++++++++[m[31m------[m
 src/dotnet-g23/Models/Domain/Invitation.cs         |  1 [32m+[m
 src/dotnet-g23/Models/Domain/Lector.cs             |  4 [32m++[m[31m--[m
 src/dotnet-g23/Models/Domain/Motivation.cs         |  5 [32m++[m[31m---[m
 src/dotnet-g23/Models/Domain/Organization.cs       |  6 [32m+++[m[31m---[m
 src/dotnet-g23/Models/Domain/Participant.cs        |  5 [32m+++[m[31m--[m
 .../Models/Domain/State/ApprovedState.cs           |  3 [32m+++[m
 src/dotnet-g23/Models/Domain/State/Context.cs      | 11 [32m+++++[m[31m-----[m
 src/dotnet-g23/Models/Domain/State/InitialState.cs |  8 [32m+++++[m[31m--[m
 src/dotnet-g23/Models/Domain/State/State.cs        | 16 [32m++++++++++++[m[31m--[m
 .../Models/Domain/State/SubmittedState.cs          | 12 [32m+++++++[m[31m----[m
 src/dotnet-g23/Models/Domain/UserState.cs          |  3 [32m++[m[31m-[m
 13 files changed, 71 insertions(+), 46 deletions(-)

[33mcommit 19782dfe40e983a74700e26741f4a4bb9aab12f5[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 16:16:21 2017 +0100

    Resolve cyclical database dependencies

 src/dotnet-g23/Data/ApplicationDbContext.cs        |  21 [32m+[m[31m-[m
 .../20170302150808_CreateBaseSchema.Designer.cs    | 392 [31m---------------[m
 ...70304144925_AddDomainToOrganization.Designer.cs | 395 [31m----------------[m
 .../20170304144925_AddDomainToOrganization.cs      |  25 [31m-[m
 .../20170304145141_AddNotifications.Designer.cs    | 437 [31m-----------------[m
 .../Migrations/20170304145141_AddNotifications.cs  |  59 [31m---[m
 ...5083636_EnsureCapitalizedTableNames.Designer.cs | 437 [31m-----------------[m
 .../20170305083636_EnsureCapitalizedTableNames.cs  | 235 [31m---------[m
 ...20170305090454_EnsureRequiredFields.Designer.cs | 439 [31m-----------------[m
 .../20170305090454_EnsureRequiredFields.cs         |  52 [31m--[m
 .../20170305133958_RenameNotification.Designer.cs  | 439 [31m-----------------[m
 .../20170305133958_RenameNotification.cs           | 102 [31m----[m
 ...20170307112550_DropTableMotivations.Designer.cs | 430 [31m-----------------[m
 .../20170307112550_DropTableMotivations.cs         |  24 [31m-[m
 .../Migrations/20170307113451_ReAddMotivations.cs  |  54 [31m---[m
 .../20170309085908_AddStateMachine.Designer.cs     | 523 [31m---------------------[m
 .../Migrations/20170309085908_AddStateMachine.cs   |  65 [31m---[m
 ...=> 20170311151108_CreateBaseSchema.Designer.cs} |  32 [32m+[m[31m-[m
 ...chema.cs => 20170311151108_CreateBaseSchema.cs} | 236 [32m+++++++[m[31m---[m
 .../ApplicationDbContextModelSnapshot.cs           | 101 [32m+[m[31m---[m
 20 files changed, 204 insertions(+), 4294 deletions(-)

[33mcommit ec161a85f4eaae107baa1de4d20ca15d0d2cb493[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 15:07:01 2017 +0100

    Deduplicate EF core database mappings

 src/dotnet-g23/Data/ApplicationDbContext.cs | 100 [32m+++++++++++++++++[m[31m-----------[m
 1 file changed, 60 insertions(+), 40 deletions(-)

[33mcommit 2263418bdd5042506a104877251170ba3e3c8bc0[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 11 14:40:55 2017 +0100

    Don't catch DataInitializer exceptions

 src/dotnet-g23/Startup.cs | 7 [32m+[m[31m------[m
 1 file changed, 1 insertion(+), 6 deletions(-)

[33mcommit 3d248d0a833f46b6b75125a2dd153902d3463584[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 15:47:10 2017 +0100

    Start db purge

 src/dotnet-g23/Data/ApplicationDbContext.cs        | 65 [32m++[m[31m--------------------[m
 src/dotnet-g23/Models/Domain/Group.cs              |  3 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/Lector.cs             |  3 [32m+[m[31m-[m
 .../{ => Repositories}/IInvitationRepository.cs    |  0
 4 files changed, 9 insertions(+), 62 deletions(-)

[33mcommit d39a293d76b1cfd6713e778a59950352a125b291[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 15:51:29 2017 +0100

    Fix login button

 src/dotnet-g23/Views/Account/Login.cshtml | 9 [32m++++[m[31m-----[m
 1 file changed, 4 insertions(+), 5 deletions(-)

[33mcommit 7746457d037556856ad765b47ec8693502808c75[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Fri Mar 10 18:41:49 2017 +0100

    Fix wrong motivations in initializer

 src/dotnet-g23/Data/DataInitializer.cs | 12 [32m++[m[31m----------[m
 1 file changed, 2 insertions(+), 10 deletions(-)

[33mcommit 1ddcacc0a52434df9badccdc7e0fca1fc6f57e09[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Thu Mar 9 15:30:12 2017 +0100

    updadte class diagram

 vpp/dotnet-g23.vpp | Bin [31m759808[m -> [32m759808[m bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

[33mcommit 1b084f46c9ea2c3638d15ec7b42422490621f0c2[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 14:47:05 2017 +0100

    Undo remove group filter

 src/dotnet-g23/Controllers/GroupController.cs | 4 [32m++[m[31m--[m
 1 file changed, 2 insertions(+), 2 deletions(-)

[33mcommit 35aaaa74075603ffb2a81aad75ffe69ba08417c9[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 14:10:48 2017 +0100

    Order list

 src/dotnet-g23/Controllers/GroupController.cs        |  2 [32m+[m[31m-[m
 src/dotnet-g23/Controllers/OrganizationController.cs | 17 [32m+++++[m[31m------------[m
 2 files changed, 6 insertions(+), 13 deletions(-)

[33mcommit 78cdeaf7dd5e76a63580b1373f54eb0032e75ec6[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 14:03:52 2017 +0100

    Fix GUser registration

 src/dotnet-g23/Controllers/AccountController.cs | 17 [32m++++++++++++++++[m[31m-[m
 1 file changed, 16 insertions(+), 1 deletion(-)

[33mcommit c3fc67956c8c0c7656a86e0214f4b69c9366f2a6[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 13:51:29 2017 +0100

    Fix registration

 src/dotnet-g23/Views/Account/Register.cshtml | 7 [32m+++[m[31m----[m
 1 file changed, 3 insertions(+), 4 deletions(-)

[33mcommit 9a37ae8960119d6218f41d5ee889d8420fd598da[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 13:42:44 2017 +0100

    Remove site.css

 src/dotnet-g23/wwwroot/css/site.css     | 38 [31m---------------------------------[m
 src/dotnet-g23/wwwroot/css/site.min.css |  1 [31m-[m
 2 files changed, 39 deletions(-)

[33mcommit dba91b1cc209b912ab1a31f77fbd2084b909a35d[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Thu Mar 9 13:41:14 2017 +0100

    Rename testmethod

 dotnet-g23.Tests/Models/UserTest.cs | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 1e09e132642d1296c7f3248dd2ca2ab5d0348ebe[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Thu Mar 9 12:36:42 2017 +0100

    Update class diagram

 vpp/dotnet-g23.vpp | Bin [31m759808[m -> [32m759808[m bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

[33mcommit aaa6b904674a30e5249a61283e891cfcf51e77bb[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 11:36:15 2017 +0100

    Check modelstate

 src/dotnet-g23/Controllers/MotivationController.cs | 20 [32m+++++++++[m[31m-----------[m
 src/dotnet-g23/wwwroot/css/gad.css                 |  5 [32m+++++[m
 src/dotnet-g23/wwwroot/css/site.css                |  7 [31m-------[m
 3 files changed, 14 insertions(+), 18 deletions(-)

[33mcommit 5e05824b6bfa9c218235e3ba82f1082a1e54d562[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 11:06:59 2017 +0100

    Registration confirmation

 src/dotnet-g23/Controllers/OrganizationController.cs | 3 [32m++[m[31m-[m
 src/dotnet-g23/Views/Organization/Index.cshtml       | 5 [32m++++[m[31m-[m
 2 files changed, 6 insertions(+), 2 deletions(-)

[33mcommit fd092b2e8a4b6a923a19e2d5fb9127742d3d9b29[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 11:00:36 2017 +0100

    Always show query input

 src/dotnet-g23/Controllers/OrganizationController.cs |  3 [32m+[m[31m--[m
 src/dotnet-g23/Views/Organization/Index.cshtml       | 10 [32m+++++[m[31m-----[m
 2 files changed, 6 insertions(+), 7 deletions(-)

[33mcommit 8ee7e8c75def09ddc75b934591ed3fcb530a9479[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 10:57:39 2017 +0100

    Search query in input field

 src/dotnet-g23/Views/Organization/Index.cshtml | 6 [32m+++[m[31m---[m
 1 file changed, 3 insertions(+), 3 deletions(-)

[33mcommit 0e1a7f5966cd40308a63dcf02249b3d83aeee80e[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 10:32:29 2017 +0100

    Context mapping

 src/dotnet-g23/Controllers/GroupController.cs      |  2 [32m+[m[31m-[m
 src/dotnet-g23/Controllers/MotivationController.cs | 24 [32m+++++++++++++[m[31m--[m
 src/dotnet-g23/Data/ApplicationDbContext.cs        | 34 [32m++++++++++++++++++++++[m
 .../Data/Repositories/GroupRepository.cs           |  6 [32m+++[m[31m-[m
 src/dotnet-g23/Models/Domain/Group.cs              |  2 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/State/Context.cs      |  3 [32m++[m
 src/dotnet-g23/Models/Domain/State/State.cs        |  4 [32m+++[m
 src/dotnet-g23/Views/Group/Index.cshtml            |  5 [32m+++[m[31m-[m
 src/dotnet-g23/Views/Group/Show.cshtml             | 17 [32m+++++++++[m[31m--[m
 9 files changed, 88 insertions(+), 9 deletions(-)

[33mcommit 4bdc17e2563a0144c1768403ff686abe08998c18[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 10:02:31 2017 +0100

    State Machine DB mapping

 .../20170309085908_AddStateMachine.Designer.cs     | 523 [32m+++++++++++++++++++++[m
 .../Migrations/20170309085908_AddStateMachine.cs   |  65 [32m+++[m
 .../ApplicationDbContextModelSnapshot.cs           |  75 [32m+++[m
 3 files changed, 663 insertions(+)

[33mcommit f5c7d1e4db9a83a83504681d9066babaed76c7a6[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 09:29:02 2017 +0100

    Email fields

 src/dotnet-g23/Views/Motivation/Show.cshtml | 4 [32m++[m[31m--[m
 1 file changed, 2 insertions(+), 2 deletions(-)

[33mcommit 4536a98533487b0f95d122fc3cd3c5048bd353d5[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 4 14:31:06 2017 +0100

    Draft state machine

 dotnet-g23.Tests/Models/State/StateTest.cs         | 71 [32m++++++++++++++++++++++[m
 dotnet-g23.Tests/project.json                      |  1 [32m+[m
 src/dotnet-g23/Models/Domain/Group.cs              |  3 [32m+[m
 .../Models/Domain/State/ApprovedState.cs           | 11 [32m++++[m
 src/dotnet-g23/Models/Domain/State/Context.cs      | 34 [32m+++++++++++[m
 src/dotnet-g23/Models/Domain/State/InitialState.cs | 15 [32m+++++[m
 src/dotnet-g23/Models/Domain/State/State.cs        | 19 [32m++++++[m
 .../Models/Domain/State/StateException.cs          | 11 [32m++++[m
 .../Models/Domain/State/SubmittedState.cs          | 20 [32m++++++[m
 9 files changed, 185 insertions(+)

[33mcommit d3c58019d3ae9a0344ad5e762df33088c8cfa644[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Thu Mar 9 10:27:36 2017 +0100

    Update class diagram

 vpp/dotnet-g23.vpp | Bin [31m688128[m -> [32m759808[m bytes
 1 file changed, 0 insertions(+), 0 deletions(-)

[33mcommit 5aa9ff36c276fdefcca6abe21f31b9834f931e5b[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Thu Mar 9 10:17:43 2017 +0100

    Add Group to GUser Tuur

 src/dotnet-g23/Data/DataInitializer.cs | 1 [32m+[m
 1 file changed, 1 insertion(+)

[33mcommit 62d1d51a43fa21aaa6bdafa646666a55bb4bc2f2[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Thu Mar 9 09:11:48 2017 +0100

    POST /Motivations/{id}

 src/dotnet-g23/Controllers/MotivationController.cs |  8 [32m+[m[31m---[m
 src/dotnet-g23/Views/Group/Show.cshtml             |  4 [32m++[m
 src/dotnet-g23/Views/Motivation/Show.cshtml        | 48 [32m++++++++++++[m[31m----------[m
 src/dotnet-g23/wwwroot/css/site.css                |  7 [32m++++[m
 4 files changed, 40 insertions(+), 27 deletions(-)

[33mcommit 68522f5381d846ee66afc26efd09d75a1f89c6a1[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 20:49:03 2017 +0100

    Motivation#Show views

 src/dotnet-g23/Views/Motivation/Show.cshtml   | 63 [32m+++++++++++++++++++++++++[m[31m--[m
 src/dotnet-g23/Views/Motivation/Submit.cshtml |  4 [31m--[m
 src/dotnet-g23/wwwroot/css/gad.css            |  3 [32m++[m
 3 files changed, 63 insertions(+), 7 deletions(-)

[33mcommit c8eded0ba75871f3d11db3d4714b36e4a915ce00[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 19:31:19 2017 +0100

    Start Motivation views

 src/dotnet-g23/Controllers/MotivationController.cs | 44 [32m++++++++++++[m[31m----------[m
 .../MotivationViewModels/IndexViewModel.cs         |  4 [32m+[m[31m-[m
 src/dotnet-g23/Startup.cs                          |  1 [31m-[m
 src/dotnet-g23/Views/Group/Show.cshtml             | 17 [32m+++++++++[m
 .../{CheckMotivation.cshtml => Check.cshtml}       |  0
 src/dotnet-g23/Views/Motivation/Index.cshtml       | 38 [31m-------------------[m
 src/dotnet-g23/Views/Motivation/Show.cshtml        | 25 [32m++++++++++++[m
 .../{RegisterMotivation.cshtml => Submit.cshtml}   |  0
 src/dotnet-g23/Views/Shared/_Layout.cshtml         |  2 [32m+[m[31m-[m
 9 files changed, 70 insertions(+), 61 deletions(-)

[33mcommit 918afb59dbe12fcda995d5372edcaad294a2e7c5[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:56:28 2017 +0100

    Fix non-recursive relations

 src/dotnet-g23/Controllers/GroupController.cs                      | 1 [32m+[m
 src/dotnet-g23/Models/ViewModels/GroupViewModels/IndexViewModel.cs | 1 [32m+[m
 src/dotnet-g23/Views/Group/Index.cshtml                            | 2 [32m+[m[31m-[m
 3 files changed, 3 insertions(+), 1 deletion(-)

[33mcommit b4bc8cf66226035b719320a5834bea876900ed0f[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:50:21 2017 +0100

    Make-a the group-a page-a a bit better-a

 src/dotnet-g23/Views/Group/Index.cshtml | 6 [32m+++[m[31m---[m
 1 file changed, 3 insertions(+), 3 deletions(-)

[33mcommit dcc77959b7ddf8f713290b7811ebaa7e4f752682[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:29:02 2017 +0100

    Reorganize and fix GroupController

 src/dotnet-g23/Controllers/GroupController.cs | 98 [32m++++++++++++++[m[31m-------------[m
 1 file changed, 51 insertions(+), 47 deletions(-)

[33mcommit 5fd78cb81b970b2c7df2159f7eec1a0c68ba3179[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:28:00 2017 +0100

    Add danger triangle

 src/dotnet-g23/Views/Shared/_Messages.cshtml | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 9799ca32aff7fbba7f3d39520aa059c641f57482[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:26:29 2017 +0100

    Add info icons

 src/dotnet-g23/Views/Group/Index.cshtml | 6 [32m+++[m[31m---[m
 1 file changed, 3 insertions(+), 3 deletions(-)

[33mcommit 92f342ca3289867d8bf5bbd94e93aab11592ccac[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 18:26:20 2017 +0100

    Show open or closed status

 src/dotnet-g23/Views/Group/Show.cshtml | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 0336d82014406ceee9cb16d8d58cf118727ccde5[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 17:22:30 2017 +0100

    Rename NotificationRepository to InvitationRepository

 ...cationRepository.cs => InvitationRepository.cs} | 22 [32m+++++++++++[m[31m-----------[m
 .../Models/Domain/IInvitationRepository.cs         | 15 [32m+++++++++++++++[m
 .../Models/Domain/INotificationRepository.cs       | 15 [31m---------------[m
 src/dotnet-g23/Startup.cs                          |  2 [32m+[m[31m-[m
 4 files changed, 27 insertions(+), 27 deletions(-)

[33mcommit 191cf207e45b8451576af5a82e1e3f1e0cdbdea5[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sat Mar 4 17:15:55 2017 +0100

    Implement NotificationRepository

 .../Data/Repositories/NotificationRepository.cs    | 47 [32m++++++++++++++++++++++[m
 .../Models/Domain/INotificationRepository.cs       | 15 [32m+++++++[m
 src/dotnet-g23/Startup.cs                          |  1 [32m+[m
 3 files changed, 63 insertions(+)

[33mcommit e7efbc382e676b2a58dc8f04f289deb566823379[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 18:26:13 2017 +0100

    Update RegisterMotivation + CheckMotivation

 src/dotnet-g23/Controllers/MotivationController.cs | 18 [32m+++++++++++[m[31m-------[m
 1 file changed, 11 insertions(+), 7 deletions(-)

[33mcommit 48e2a1a908ada8bf88fccf3d474d77bd332d4b6b[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 18:09:53 2017 +0100

    Fix wrong comment

 src/dotnet-g23/Controllers/MotivationController.cs | 15 [32m+++++++++++[m[31m----[m
 src/dotnet-g23/Views/Account/Login.cshtml          |  2 [32m+[m[31m-[m
 2 files changed, 12 insertions(+), 5 deletions(-)

[33mcommit 46beae11cdda30b24fb3bbd9d871a71218d173bb[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 17:45:43 2017 +0100

    change route on RegisterMotivation

 src/dotnet-g23/Controllers/MotivationController.cs | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit e6c459cffb3d78e276c0db9b83a8b0f61fd0a0ac[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Wed Mar 8 17:54:30 2017 +0100

    Register LectorFilter

 src/dotnet-g23/Startup.cs | 1 [32m+[m
 1 file changed, 1 insertion(+)

[33mcommit de9a2445b252e679fa7835e9842428ef538dce77[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 17:07:36 2017 +0100

    add test view

 src/dotnet-g23/Controllers/MotivationController.cs |  2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Motivation/Index.cshtml       | 37 [32m++++++++++++++++++++[m[31m--[m
 2 files changed, 36 insertions(+), 3 deletions(-)

[33mcommit dde04c4007078ecf54c20ed0976ad2c0d06fa790[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 16:51:25 2017 +0100

    Update index part controller

 src/dotnet-g23/Controllers/MotivationController.cs   | 20 [32m+++++++++++++[m[31m-------[m
 .../MotivationViewModels/IndexViewModel.cs           |  2 [32m++[m
 2 files changed, 15 insertions(+), 7 deletions(-)

[33mcommit 4aa0599e78cccec08a9d579206967ec2f1c1cab8[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Wed Mar 8 16:34:05 2017 +0100

    Update lectorfilter

 src/dotnet-g23/Controllers/MotivationController.cs | 29 [32m+++++++++++++[m[31m---------[m
 src/dotnet-g23/Filters/LectorFilter.cs             | 26 [32m+++[m[31m----------------[m
 2 files changed, 21 insertions(+), 34 deletions(-)

[33mcommit ef0e75c01adc4189c97e5fcd785118a0b42f171d[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Tue Mar 7 22:16:06 2017 +0100

    Add CheckMotivation to controller

 src/dotnet-g23/Controllers/MotivationController.cs | 33 [32m++++++++++++++++[m[31m------[m
 .../MotivationViewModels/CheckViewModel.cs         | 15 [32m++++++++++[m
 2 files changed, 39 insertions(+), 9 deletions(-)

[33mcommit 0449b7089c7041455c15c841153e9c96fe165e73[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Tue Mar 7 21:57:27 2017 +0100

    Add RegisterMotivation

 src/dotnet-g23/Controllers/MotivationController.cs          | 11 [32m+++++++++[m[31m--[m
 .../ViewModels/MotivationViewModels/RegisterViewModel.cs    | 13 [32m+++++++++++++[m
 2 files changed, 22 insertions(+), 2 deletions(-)

[33mcommit b672e6ba44567307e6d6d19159b4d765b488509e[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Wed Mar 8 12:49:15 2017 +0000

    Group index buttons + svg klassendiagram

 src/dotnet-g23/Views/Group/Index.cshtml |    6 [32m+[m[31m-[m
 vpp/vpp.svg                             | 1641 [32m+++++++++++++++++++++++++++++++[m
 2 files changed, 1644 insertions(+), 3 deletions(-)

[33mcommit 02cbd69379a9426b8c7cc60b52f8904b01a564c4[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Wed Mar 8 12:27:03 2017 +0000

    responsief group show + card margin

 src/dotnet-g23/Views/Group/Show.cshtml | 8 [32m+++++[m[31m---[m
 src/dotnet-g23/wwwroot/css/gad.css     | 2 [32m+[m[31m-[m
 2 files changed, 6 insertions(+), 4 deletions(-)

[33mcommit fca1a60dc6e0e8a49ad75e351dbdcd387bea5a60[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Wed Mar 8 12:18:24 2017 +0000

    responsive groep aanmaken button

 src/dotnet-g23/Views/Group/Index.cshtml | 14 [32m+++++++++[m[31m-----[m
 1 file changed, 9 insertions(+), 5 deletions(-)

[33mcommit c90277404ea835377c4cdd413bc6f953345796d4[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Wed Mar 8 11:55:36 2017 +0000

    responsive search bar in organisations

 src/dotnet-g23/Views/Organization/Index.cshtml |  2 [32m+[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css             | 11 [32m++++++++++[m[31m-[m
 2 files changed, 11 insertions(+), 2 deletions(-)

[33mcommit 41cd35a05d1187e2f7902a9ae1d801eea798f96d[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Wed Mar 8 11:36:09 2017 +0000

    remove p from cards + align buttons with text

 src/dotnet-g23/Views/Group/Index.cshtml        | 18 [32m++++++[m[31m------------[m
 src/dotnet-g23/Views/Organization/Index.cshtml | 16 [32m++++++[m[31m----------[m
 src/dotnet-g23/wwwroot/css/gad.css             |  7 [32m++++[m[31m---[m
 3 files changed, 16 insertions(+), 25 deletions(-)

[33mcommit 8d63ce8830b2967b15de0b3a9c42da7808178758[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 22:42:34 2017 +0000

    fixed alert box error

 src/dotnet-g23/Views/Organization/Index.cshtml | 2 [32m+[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css             | 2 [32m+[m[31m-[m
 2 files changed, 2 insertions(+), 2 deletions(-)

[33mcommit 5ac918a27f0265bbef250012a0bbaebd89740c27[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 22:28:09 2017 +0000

    small style change to cards

 src/dotnet-g23/Views/Organization/Index.cshtml |  2 [32m+[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css             | 11 [32m++++++++++[m[31m-[m
 2 files changed, 11 insertions(+), 2 deletions(-)

[33mcommit ffc8bb20ca13c4b3308952fcfb12392a4287f3e5[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 20:26:15 2017 +0000

    redirect participants to organisations/

 src/dotnet-g23/Controllers/AccountController.cs | 4 [32m++[m[31m--[m
 1 file changed, 2 insertions(+), 2 deletions(-)

[33mcommit a0fd157989f27402b01e38c06f44476be3a2e1bc[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 19:44:42 2017 +0000

    redirect logout to login page (closes #24)

 src/dotnet-g23/Controllers/AccountController.cs | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 4157188cdec008d06091f842c46fbc353e1ed6b8[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 19:36:12 2017 +0000

    disabled account manager link

 src/dotnet-g23/Controllers/AccountController.cs  |  1 [32m+[m
 src/dotnet-g23/Views/Shared/_LoginPartial.cshtml |  2 [32m+[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css               | 10 [32m++++++++++[m
 3 files changed, 12 insertions(+), 1 deletion(-)

[33mcommit 15296105f54a8a8da31b6b51ad9b34b45ddf5cd8[m
Merge: f45389f 7ae6790
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 18:41:35 2017 +0000

    merge responsive with master

[33mcommit f45389f104ccee36f119587ab268c9ac603eb00d[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 18:14:22 2017 +0000

    convert register to house style

 src/dotnet-g23/Views/Account/Register.cshtml | 91 [32m++++++++++++++++[m[31m------------[m
 1 file changed, 52 insertions(+), 39 deletions(-)

[33mcommit 767bd82a98614f8d6936bbeee4e038f44ab675b0[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 18:13:01 2017 +0000

    added floating rules for buttons

 src/dotnet-g23/Views/Account/Login.cshtml | 12 [32m++[m[31m---[m
 src/dotnet-g23/wwwroot/css/gad.css        | 75 [32m+++++++++++++++++++++++++++++[m[31m--[m
 2 files changed, 78 insertions(+), 9 deletions(-)

[33mcommit 39053bf190824af0d3a1ba98f0ddb435d6e0de3a[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 15:59:53 2017 +0000

    converted login buttons to house style

 src/dotnet-g23/Views/Account/Login.cshtml | 30 [32m++++++++++++++++++[m[31m------------[m
 1 file changed, 18 insertions(+), 12 deletions(-)

[33mcommit da57648c1cbec010c7d1e855f16419b2f5840481[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 15:44:54 2017 +0000

    convert login to house style

 src/dotnet-g23/Views/Account/Login.cshtml | 35 [32m++++++++++++++++++++[m[31m-----------[m
 1 file changed, 23 insertions(+), 12 deletions(-)

[33mcommit 7ae67900d15cc1b5de79dd965e1cf356e7d7c99b[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 16:29:38 2017 +0100

    Remove test groups

 src/dotnet-g23/Data/DataInitializer.cs         | 3 [31m---[m
 src/dotnet-g23/Views/Organization/Index.cshtml | 2 [32m+[m[31m-[m
 2 files changed, 1 insertion(+), 4 deletions(-)

[33mcommit e70561f4caf9c9c18f6e8eb0348de701b5af0563[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 16:24:19 2017 +0100

    Groups#Invite action

 src/dotnet-g23/Controllers/GroupController.cs      | 46 [32m++++++++++++++[m[31m--------[m
 .../Controllers/OrganizationController.cs          |  4 [32m+[m[31m-[m
 src/dotnet-g23/Views/Group/Create.cshtml           |  2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Organization/Index.cshtml     |  4 [32m+[m[31m-[m
 src/dotnet-g23/Views/Shared/_Messages.cshtml       | 12 [32m+++++[m[31m-[m
 5 files changed, 44 insertions(+), 24 deletions(-)

[33mcommit 78fbfd5995229eb9522a57ede0dc72b6ed3fb053[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 16:04:39 2017 +0100

    Group#Invite page

 src/dotnet-g23/Controllers/GroupController.cs | 27 [32m+++++++++++++++[m[31m------------[m
 src/dotnet-g23/Views/Group/Index.cshtml       | 12 [32m+++++++[m[31m-----[m
 src/dotnet-g23/Views/Group/Invite.cshtml      | 12 [32m+++++++[m[31m-----[m
 src/dotnet-g23/Views/Group/Show.cshtml        |  2 [32m+[m[31m-[m
 4 files changed, 30 insertions(+), 23 deletions(-)

[33mcommit b65e111a74455e1bab681b1fb7c0a716e6f3117e[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 16:04:29 2017 +0100

    Review Organizations#Index

 src/dotnet-g23/Views/Organization/Index.cshtml | 53 [32m++++++++++[m[31m----------------[m
 1 file changed, 20 insertions(+), 33 deletions(-)

[33mcommit 4e6dd689674d340443e95f725a19f8a5716ae40b[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 15:28:38 2017 +0100

    Show number of participants

 src/dotnet-g23/Data/DataInitializer.cs  |   9 [32m+++[m
 src/dotnet-g23/Models/Domain/Group.cs   |   2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Group/Index.cshtml |   4 [32m+[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css      | 118 [32m++++++++++++++++++++++++++++++++[m
 4 files changed, 130 insertions(+), 3 deletions(-)

[33mcommit 01d71ac7d5cfafb343a658781fda23dcbb292ed0[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 12:59:03 2017 +0100

    Change logout button

 src/dotnet-g23/Views/Shared/_LoginPartial.cshtml | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 3b72ad2a2f78ff1eb7b469a62393399aa5575098[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 12:52:29 2017 +0100

    Show group participants

 src/dotnet-g23/Controllers/GroupController.cs    |  3 [32m+[m[31m--[m
 src/dotnet-g23/Views/Group/Index.cshtml          |  4 [32m++[m[31m--[m
 src/dotnet-g23/Views/Group/Invite.cshtml         |  2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Group/Show.cshtml           | 21 [32m+++++++++++++++++++[m[31m--[m
 src/dotnet-g23/Views/Shared/_LoginPartial.cshtml |  2 [32m+[m[31m-[m
 5 files changed, 24 insertions(+), 8 deletions(-)

[33mcommit d76fdea3fe88c49ede5c02d7e8ce16a94b598d06[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 12:42:39 2017 +0100

    Fix group registration

 src/dotnet-g23/Controllers/GroupController.cs | 31 [32m++++++++++++++++++++[m[31m-------[m
 src/dotnet-g23/Views/Group/Index.cshtml       |  5 [32m++++[m[31m-[m
 src/dotnet-g23/Views/Group/Invite.cshtml      | 22 [32m+++++++++++++++++++[m
 src/dotnet-g23/Views/Group/Show.cshtml        |  7 [32m++++++[m
 4 files changed, 56 insertions(+), 9 deletions(-)

[33mcommit db7d5731253116b88953dd3466235645096ccb28[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 12:37:37 2017 +0100

    Reconfigure Group-Motivation relationship

 src/dotnet-g23/Data/ApplicationDbContext.cs        |   7 [32m+[m[31m-[m
 .../20170307113451_ReAddMotivations.Designer.cs    | 448 [32m+++++++++++++++++++++[m
 .../Migrations/20170307113451_ReAddMotivations.cs  |  54 [32m+++[m
 .../ApplicationDbContextModelSnapshot.cs           |  48 [32m+++[m
 src/dotnet-g23/Models/Domain/Motivation.cs         |   1 [32m+[m
 5 files changed, 554 insertions(+), 4 deletions(-)

[33mcommit c5dad20875434c51613a37b327e58556e09c54f4[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 12:27:11 2017 +0100

    Drop Motivations table

 ...20170307112550_DropTableMotivations.Designer.cs | 430 [32m+++++++++++++++++++++[m
 .../20170307112550_DropTableMotivations.cs         |  24 [32m++[m
 .../ApplicationDbContextModelSnapshot.cs           |  43 [32m+[m[31m--[m
 3 files changed, 456 insertions(+), 41 deletions(-)

[33mcommit cced6764e9f53d4fa53693174a717517f2cbbd2c[m
Author: Tuur Lievens <tuur.lievens@hotmail.com>
Date:   Tue Mar 7 10:57:02 2017 +0100

    Fix GetByKeyword in OrganizationRepo

 src/dotnet-g23/Data/Repositories/OrganizationRepository.cs | 2 [32m+[m[31m-[m
 1 file changed, 1 insertion(+), 1 deletion(-)

[33mcommit 087406db74fa16a82e9e1a5dfefb4b73584e8c42[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 10:46:25 2017 +0100

    Move errorhandling to Group

 src/dotnet-g23/Controllers/GroupController.cs | 26 [32m++++++++++++++[m[31m------------[m
 src/dotnet-g23/Models/Domain/Group.cs         |  2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Group/Create.cshtml      |  3 [32m++[m[31m-[m
 src/dotnet-g23/Views/Shared/_Messages.cshtml  |  2 [32m+[m[31m-[m
 4 files changed, 18 insertions(+), 15 deletions(-)

[33mcommit 3da2efb5d8b36d8dc14cbabbe5deefef267759e3[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 10:38:41 2017 +0100

    Initialize associations in default constructor

 src/dotnet-g23/Models/Domain/GUser.cs        | 3 [32m++[m[31m-[m
 src/dotnet-g23/Models/Domain/Group.cs        | 5 [32m++++[m[31m-[m
 src/dotnet-g23/Models/Domain/Lector.cs       | 7 [32m+++++++[m
 src/dotnet-g23/Models/Domain/Organization.cs | 8 [32m+++++[m[31m---[m
 4 files changed, 18 insertions(+), 5 deletions(-)

[33mcommit 18474f11543ff447cb4c99edbebd4032bfa1bb3a[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 10:01:44 2017 +0100

    Group#Create: update view

 src/dotnet-g23/Views/Group/Create.cshtml | 33 [32m++++++++++++++++++++[m[31m------------[m
 1 file changed, 21 insertions(+), 12 deletions(-)

[33mcommit 9847862315eb3961ad5994c90a351ac81f9048d1[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Tue Mar 7 09:50:37 2017 +0100

    Group#Index: add alerts

 src/dotnet-g23/Views/Group/Index.cshtml | 35 [32m+++++++++++++++++++++++++[m[31m--------[m
 1 file changed, 27 insertions(+), 8 deletions(-)

[33mcommit 54a57ba693fc21646a2c57672d0fc4c602955d79[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sun Mar 5 15:22:56 2017 +0100

    Start group registration

 dotnet-g23.Tests/Models/InvitationTest.cs          | 27 [32m+++++++++++[m
 dotnet-g23.Tests/Models/NotificationTest.cs        | 27 [31m-----------[m
 src/dotnet-g23/Controllers/GroupController.cs      | 31 [32m++++++++++[m[31m---[m
 .../Controllers/OrganizationController.cs          |  2 [32m+[m[31m-[m
 src/dotnet-g23/Filters/ParticipantFilter.cs        |  7 [32m++[m[31m-[m
 src/dotnet-g23/Models/Domain/Organization.cs       |  4 [32m+[m[31m-[m
 .../ViewModels/GroupViewModels/IndexViewModel.cs   | 15 [32m++++++[m
 src/dotnet-g23/Startup.cs                          |  1 [32m+[m
 src/dotnet-g23/Views/Group/Index.cshtml            | 53 [32m++++++++++++++++++++[m[31m--[m
 9 files changed, 125 insertions(+), 42 deletions(-)

[33mcommit 1ac59ccd120763a80f9e88277299f381fb4d934f[m
Author: Florian Dejonckheere <florian@floriandejonckheere.be>
Date:   Sun Mar 5 14:40:42 2017 +0100

    Rename Notification to Invitation

 src/dotnet-g23/Data/ApplicationDbContext.cs        |  14 [32m+[m[31m-[m
 .../20170305133958_RenameNotification.Designer.cs  | 439 [32m+++++++++++++++++++++[m
 .../20170305133958_RenameNotification.cs           | 102 [32m+++++[m
 .../ApplicationDbContextModelSnapshot.cs           |  64 [32m+[m[31m--[m
 src/dotnet-g23/Models/Domain/GUser.cs              |   2 [32m+[m[31m-[m
 src/dotnet-g23/Models/Domain/Group.cs              |   7 [32m+[m[31m-[m
 .../Domain/{Notification.cs => Invitation.cs}      |   8 [32m+[m[31m-[m
 7 files changed, 591 insertions(+), 45 deletions(-)

[33mcommit 1f24ac518e70cf0154609c704c393e057d0652d9[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Tue Mar 7 11:45:39 2017 +0100

    Update DataInitializer

 src/dotnet-g23/Data/DataInitializer.cs | 105 [32m++++++++++++++++[m[31m-----------------[m
 1 file changed, 51 insertions(+), 54 deletions(-)

[33mcommit 9b06f852fed707a3a3dfe5c7262e676df9070115[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Tue Mar 7 11:18:32 2017 +0100

    Update motivationcontroller

 src/dotnet-g23/Controllers/MotivationController.cs | 11 [32m+++[m[31m--[m
 src/dotnet-g23/Data/DataInitializer.cs             | 50 [32m+++++++++++[m[31m-----------[m
 .../MotivationViewModels/IndexViewModel.cs         | 13 [32m++++++[m
 src/dotnet-g23/Views/Motivation/Index.cshtml       |  5 [32m+++[m
 4 files changed, 50 insertions(+), 29 deletions(-)

[33mcommit 9418c0e8c7afa10eb6b67874d64c9a564dd91d3b[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 20:44:49 2017 +0100

    Update DbContext and DataInitializerr to add motivations

 src/dotnet-g23/Data/ApplicationDbContext.cs |  1 [32m+[m
 src/dotnet-g23/Data/DataInitializer.cs      | 35 [32m+++++++++++++++++++++++++++++[m
 2 files changed, 36 insertions(+)

[33mcommit 6be72d6f625704f471256c1324f312aff404474c[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 20:10:52 2017 +0100

    Add groups to initializer

 src/dotnet-g23/Data/DataInitializer.cs | 19 [32m+++++++++++++++++++[m
 1 file changed, 19 insertions(+)

[33mcommit 75c2d439a252f0ce5773cd39d87bef84c54a1d5e[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 19:53:53 2017 +0100

    Start implement MotivationController

 src/dotnet-g23/Controllers/MotivationController.cs | 30 [32m++++++++++++++[m[31m--------[m
 1 file changed, 20 insertions(+), 10 deletions(-)

[33mcommit 0936a471142ddcba16e4379041625be36ecbe377[m
Author: JasperDhaene <jasper.dhaene@hotmail.com>
Date:   Tue Mar 7 12:04:54 2017 +0000

    responsive footer + changes to home

 src/dotnet-g23/Views/Home/Index.cshtml     |   8 [32m+[m[31m-[m
 src/dotnet-g23/Views/Shared/_Layout.cshtml |  17 [32m++++[m[31m-[m
 src/dotnet-g23/wwwroot/css/gad.css         | 117 [32m+++++++[m[31m----------------------[m
 3 files changed, 44 insertions(+), 98 deletions(-)

[33mcommit 2eba074dc31924b601539e0644e14843e139515d[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 18:31:48 2017 +0100

    Set method in OrganizationRepository

 src/dotnet-g23/Controllers/OrganizationController.cs                 | 2 [32m+[m[31m-[m
 src/dotnet-g23/Data/Repositories/OrganizationRepository.cs           | 4 [32m++++[m
 src/dotnet-g23/Models/Domain/Repositories/IOrganizationRepository.cs | 1 [32m+[m
 3 files changed, 6 insertions(+), 1 deletion(-)

[33mcommit 4793f403179a7a09bc3c7b3f8af2c27bb45652ec[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 12:07:34 2017 +0100

    Give error message if wrong query

 src/dotnet-g23/Controllers/OrganizationController.cs |  7 [32m++++++[m[31m-[m
 src/dotnet-g23/Views/Organization/Index.cshtml       | 12 [32m+++++++++++[m[31m-[m
 2 files changed, 17 insertions(+), 2 deletions(-)

[33mcommit f7b4f55b52a2036ffda34c448bcdaa0aae7a7f67[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 11:29:53 2017 +0100

    Delete js script

 src/dotnet-g23/wwwroot/_references.js                   |  1 [31m-[m
 src/dotnet-g23/wwwroot/js/CustomScripts/FilterScript.js | 15 [31m---------------[m
 2 files changed, 16 deletions(-)

[33mcommit d3b45bcb22a478e463992961866d1df9af8af368[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 10:41:18 2017 +0100

    Make textbox work

 .../Controllers/OrganizationController.cs          |  2 [32m+[m[31m-[m
 src/dotnet-g23/Views/Organization/Index.cshtml     | 35 [32m++++++[m[31m----------------[m
 2 files changed, 10 insertions(+), 27 deletions(-)

[33mcommit 6280653a31d05d0944fee94549a4ecee379f00e1[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Mon Mar 6 09:00:18 2017 +0100

    Add scripts

 src/dotnet-g23/Views/Organization/Index.cshtml          | 12 [32m++++++[m[31m------[m
 src/dotnet-g23/wwwroot/_references.js                   |  1 [32m+[m
 src/dotnet-g23/wwwroot/js/CustomScripts/FilterScript.js | 15 [32m+++++++++++++++[m
 3 files changed, 22 insertions(+), 6 deletions(-)

[33mcommit 87ff5a5b476d692107197d4da2f5e813b8aaafb5[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 22:22:23 2017 +0100

    Start implementing search

 .../Controllers/OrganizationController.cs          |  2 [32m+[m[31m-[m
 src/dotnet-g23/Data/DataInitializer.cs             |  2 [32m+[m
 src/dotnet-g23/Views/Organization/Index.cshtml     | 65 [32m++++++++++++++[m[31m--------[m
 3 files changed, 46 insertions(+), 23 deletions(-)

[33mcommit f9fc0263ea0c348ca064c96271966506f5298b11[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 20:44:36 2017 +0100

    Make test work

 dotnet-g23.Tests/Controllers/OrganizationControllerTest.cs | 12 [32m++++++[m[31m------[m
 1 file changed, 6 insertions(+), 6 deletions(-)

[33mcommit 8d6bb022246a0684bc385b48b6e27775401cb660[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 19:32:52 2017 +0100

    Start debugging test

 dotnet-g23.Tests/Data/DummyApplicationDbContext.cs   | 8 [32m++++++++[m
 src/dotnet-g23/Controllers/OrganizationController.cs | 2 [32m+[m[31m-[m
 2 files changed, 9 insertions(+), 1 deletion(-)

[33mcommit c7a13c300fb8751baea374fb44524f5c74a5dce3[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 19:18:25 2017 +0100

    Update project files

 dotnet-g23.Tests/dotnet-g23.Tests.xproj | 7 [32m++++[m[31m---[m
 1 file changed, 4 insertions(+), 3 deletions(-)

[33mcommit cd0a6691aba9b39b97c2f9531bfdd31cb5c7a589[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 19:09:29 2017 +0100

    Add Register method test

 .../Controllers/OrganizationControllerTest.cs      | 22 [32m++++++++++++++++++++++[m
 1 file changed, 22 insertions(+)

[33mcommit 807e94ac7188e3aaf1244e21536b360a8efccf7a[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 18:25:12 2017 +0100

    Add Facts to Index region methods OrganizationControllerTest

 dotnet-g23.Tests/Controllers/OrganizationControllerTest.cs | 3 [32m+++[m
 1 file changed, 3 insertions(+)

[33mcommit ffd8f7b191e9c83b70741effb36c13319cd3b45f[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 18:20:54 2017 +0100

    Add Index Test

 .../Controllers/OrganizationControllerTest.cs      | 58 [32m++++++++++++++++++++[m[31m--[m
 1 file changed, 53 insertions(+), 5 deletions(-)

[33mcommit 42a664d390e76ad63dae62d60c678ae9c9a59ab0[m
Author: PrebenLeroy <preben.leroy@live.be>
Date:   Sun Mar 5 17:34:27 2017 +0100

    Update Dummy

 .../Controllers/OrganizationControllerTest.cs      | 23 [32m++++++++++++[m[31m----------[m
 dotnet-g23.Tests/Data/DummyApplicationDbContext.cs | 16 [32m++++++++++++[m[31m---[m
 2 files changed, 26 insertions(+), 13 deletions(-)
