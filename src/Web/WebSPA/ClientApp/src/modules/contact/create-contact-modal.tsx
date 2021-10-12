import React from "react";
import {IModalProps} from "types/modal-props";
import {Button, Modal} from "react-bootstrap";


export const CreateContactModal = (props:IModalProps) => {
  return(
    <Modal show={props.Open} onHide={props.HandleClose} centered >
      <Modal.Header>
        <Modal.Title className="font-size-16">{props.Title}</Modal.Title>
        <button type="button" >
          <span aria-hidden="true">×</span>
        </button>
      </Modal.Header>
      <Modal.Body>
        <form>
          <div className="form-group mb-4">
            <label htmlFor="addcontactemail-input">Email</label>
            <input type="email" className="form-control" id="addcontactemail-input" placeholder="Enter Email"/>
          </div>
          <div className="form-group">
            <label htmlFor="addcontact-invitemessage-input">Invatation Message</label>
            <textarea className="form-control" id="addcontact-invitemessage-input"
                      placeholder="Enter Message"></textarea>
          </div>
        </form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="herf" onClick={props.HandleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={props.HandleClose}>
          Save Changes
        </Button>
      </Modal.Footer>
    </Modal>
  )
}
