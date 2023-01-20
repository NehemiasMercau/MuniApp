#!/bin/bash
## declare an array variable
# declare -a arr=("Pago")
# #dotnet aspnet-codegenerator controller -name DeudasController -m Deuda -dc MuniApp.Negocio.entidades.ODAMuniDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
# ## now loop through the above array
# for i in "${arr[@]}"
# do
#     TABLA="$i"
#     CONTROLLER="$i"Controller
#     echo $CONTROLLER
#     echo $TABLA
#     dotnet aspnet-codegenerator controller -name $CONTROLLER -m $TABLA -dc MuniApp.Negocio.entidades.ODAMuniDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
#    #echo "$i"
#    # or do whatever with individual element of the array
# done

# declare -a arr=("Arqueos" "AspNetRoles" "AspNetUsers" "Cobros" "DeudaDetalles" "Domicilios" "Entidades" "Eventualidades" "PagoDetalles" "Pagos" "Periodos" "PersonaEntidadDeudaDetalles" "Personas" "Rubros")
#declare -a arr=("PagoDetalle" "Pago" "Periodo" "PersonaEntidadDeudaDetalle" "Persona" "Rubro")
#declare -a arr=("AspNetRoles" "AspNetUsers")
# declare -a arr=("Entidad" "Eventualidad")

# # now loop through the above array
# for i in "${arr[@]}"
# do
#     TABLA="$i"
#     CONTROLLER="$i"esController
#     echo $CONTROLLER
#     echo $TABLA
#     dotnet aspnet-codegenerator controller -name $CONTROLLER -m $TABLA -dc MuniApp.Negocio.entidades.ODAMuniDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
#     echo "----------------"
#    # or do whatever with individual element of the array
# done


# You can access them using echo "${arr[0]}", "${arr[1]}" also


#dotnet aspnet-codegenerator controller -name ArqueosController -m Arqueo -dc MuniApp.Negocio.entidades.ODAMuniDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries