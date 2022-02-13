import { inject, observer } from "mobx-react";
import { useState } from "react";
import VehicleMakeModal from "./VehicleMakeModal";

const VehicleMake = ({ make }: any) => {
    const [modalIsOpen, setIsOpen] = useState(false);

    function openModal() {
        setIsOpen(true);
    }

    return (
        <tr >
            <td>{make.name}</td>
            <td>{make.abrv}</td>
            <td>
                <button onClick={openModal}>Edit</button>

                <VehicleMakeModal key={make.id} modalIsOpen={modalIsOpen} setIsOpen={setIsOpen} make={make} />
            </td>
        </tr>
    );
};

export default inject("rootStore")(observer(VehicleMake));