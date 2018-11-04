# Lullo

# Doel van de Applicaite
Het doel van de applicatie is om een portaal te zijn voor studentenhuizen. De Bedoeling is dat elk 
studentenhuis hier een account op kan maken. Op deze applicatie kunnen ze Recepten met elkaar delen en invullen. 
Verder is er een bootschappenlijst waar elke huisgenoot bootschappen kan toevoegen die gehaald moeten worden voor het hele huis.

# Applicatie offline installeren

1. Download de repo
2. Open de files in Visual Studio
3. Update alle nuget packadges
4. Run de code in visual studio

Letop: Er is geen admin account. Deze is afgeschermt. Je kan het admin account in de live versie bekijken hieronder.
Als je het toch offline wilt proberen moet je in de User view de edit file openen en deze code onderin toevoegen.

```
<div class="form-group">
                     @Html.LabelFor(model => model.IsAdmin, htmlAttributes: new {@class = "control-label col-md-2"})
                     <div class="col-md-10">
                         <div class="checkbox">
                             @Html.EditorFor(model => model.IsAdmin)
                             @Html.ValidationMessageFor(model => model.IsAdmin, "", new {@class = "text-danger"})
                         </div>
                     </div>
                 </div>
```

# User gegevens voor de live versie

###Login gegevens voor de admin
Email: admin@test.nl
Ps: test1234

###Login voor een normale gebruiker
Email: user@test.nl
Ps: test1234

Online deployed website: https://lullo.azurewebsites.net/
