import { autorun } from "mobx";
import { inject, observer } from "mobx-react";
import { useEffect } from "react";

const GetAllVehicleMakeList = ({ rootStore }) => {
    useEffect(() => autorun(() => {
        rootStore.vehicleMakeStore.getAllVehicleMakeAsync();
    }))

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Abrv
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {rootStore.vehicleMakeStore.model.map(make => (
                        <tr key={make.id}>
                            <td>{make.name}</td>
                            <td>{make.abrv}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
};

export default inject("rootStore")(observer(GetAllVehicleMakeList))