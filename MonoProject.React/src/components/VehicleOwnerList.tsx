import { inject, observer } from "mobx-react";
import { Key, ReactChild, ReactFragment, ReactPortal, useEffect } from "react";
import { autorun } from "mobx";


const VehicleOwnerList: React.FC = ({ rootStore }: any) => {
    useEffect(() => autorun(() => {
        rootStore.vehicleOwnerListViewStore?.getAllVehicleOwnerAsync();
    }), [])

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th>
                            First Name
                        </th>
                        <th>
                            Last Name
                        </th>
                        <th>
                            Date of Birth
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {rootStore.vehicleOwnerListViewStore.data.map((owner: { id: Key | null | undefined; firstName: boolean | ReactChild | ReactFragment | ReactPortal | null | undefined; lastName: boolean | ReactChild | ReactFragment | ReactPortal | null | undefined; dateOfBirth: boolean | ReactChild | ReactFragment | ReactPortal | null | undefined; }) =>
                        <tr key={owner.id}>
                            <td>{owner.firstName}</td>
                            <td>{owner.lastName}</td>
                            <td>{owner.dateOfBirth}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    )
};

export default inject("rootStore")(observer(VehicleOwnerList))