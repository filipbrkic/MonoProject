import { autorun } from "mobx";
import { inject, observer } from "mobx-react";
import { Key, ReactChild, ReactFragment, ReactPortal, useEffect, useState } from "react";
import VehicleMakeModal from "./VehicleMakeModal";

const VehicleMakeList = ({ rootStore }: any) => {
    const [modalIsOpen, setIsOpen] = useState(false);

    useEffect(() => autorun(() => {
        rootStore.vehicleMakeListViewStore?.getAllVehicleMakeAsync();
    }), [])

    function openModal() {
        setIsOpen(true);
    }

    return (
        <tbody>
            {rootStore.vehicleMakeListViewStore.data.map((make: { id: Key | null | number; name: boolean | ReactChild | ReactFragment | ReactPortal | null | string; abrv: boolean | ReactChild | ReactFragment | ReactPortal | null | string; }) =>
                <tr key={make.id}>
                    <td>{make.name}</td>
                    <td>{make.abrv}</td>
                    <td>
                        <button onClick={openModal}>Edit</button>

                        <VehicleMakeModal modalIsOpen={modalIsOpen} setIsOpen={setIsOpen} makeId={make.id} />
                    </td>
                </tr>
            )}
        </tbody>
    );
};

export default inject("rootStore")(observer(VehicleMakeList));