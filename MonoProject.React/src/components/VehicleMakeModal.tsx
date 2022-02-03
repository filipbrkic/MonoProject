import { inject, observer } from "mobx-react";
import ReactModal from "react-modal";
import UpdateVehicleMake from "./UpdateVehicleMake";


const VehicleMakeModal = ({ makeId, modalIsOpen, setIsOpen }: any) => {
    function closeModal() {
        setIsOpen(false);
    }

    return (
        <ReactModal
            isOpen={modalIsOpen}
            ariaHideApp={false}
            contentLabel="Update Modal"
        >
            <div>
                <UpdateVehicleMake id={makeId} />
                <div>

                    <button onClick={closeModal} >close</button>
                </div>
            </div>
        </ReactModal>
    );
};

export default inject("rootStore")(observer(VehicleMakeModal));