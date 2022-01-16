import { inject, observer } from "mobx-react";
import { Key, ReactChild, ReactFragment, ReactPortal, useEffect } from "react";
import { autorun } from "mobx";

const GetAllVehicleMakeList: React.FC = ({ rootStore }: any) => {
    useEffect(() => autorun(() => {
        rootStore.vehicleMakeStore?.getAllVehicleMakeAsync();
    }), [])



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
                    {rootStore.vehicleMakeStore.data.map((make: { id: Key | null | undefined; name: boolean | ReactChild | ReactFragment | ReactPortal | null | undefined; abrv: boolean | ReactChild | ReactFragment | ReactPortal | null | undefined; }) =>
                        <tr key={make.id}>
                            <td>{make.name}</td>
                            <td>{make.abrv}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
};

export default inject("rootStore")(observer(GetAllVehicleMakeList))