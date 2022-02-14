import { inject, observer } from "mobx-react";
import ReactModal from "react-modal";
import UpdateVehicleMake from "./UpdateVehicleMake";

import classes from "./VehicleMakeModal.module.css"


const VehicleMakeModal = ({ modalIsOpen, setIsOpen, make }: any) => {
    function closeModal() {
        setIsOpen(false);
    }

    return (
        <ReactModal
            isOpen={modalIsOpen}
            ariaHideApp={false}
            contentLabel="Update Modal"
            className={classes.modal}
            onRequestClose={closeModal}
        >
            <div>
                <UpdateVehicleMake make={make} closeModal={closeModal} />
            </div>
        </ReactModal>
    );
};

export default inject("rootStore")(observer(VehicleMakeModal));