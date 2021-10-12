import React from "react";
import {Button, Modal} from "react-bootstrap";
import {IModalProps} from "types/modal-props";



export const CreateGroupModal = (props:IModalProps) => {
    return(
      <Modal show={props.Open} onHide={props.HandleClose} centered>
        <Modal.Header>
          <Modal.Title className="font-size-16">{props.Title}</Modal.Title>
          <button type="button" >
            <span aria-hidden="true">×</span>
          </button>
        </Modal.Header>
        <Modal.Body>
          <form>
            <div className="form-group mb-4">
              <label htmlFor="addgroupname-input">Group Name</label>
              <input type="text" className="form-control" id="addgroupname-input" placeholder="Enter Group Name"/>
            </div>
            <div className="form-group mb-4">
              <label>Group Members</label>
              <div className="mb-3">
                <button className="btn btn-light btn-sm" type="button" data-toggle="collapse"
                        data-target="#groupmembercollapse" aria-expanded="false" aria-controls="groupmembercollapse">
                  Select Members
                </button>
              </div>

              <div className="collapse" id="groupmembercollapse">
                <div className="card border">
                  <div className="card-header">
                    <h5 className="font-size-15 mb-0">Contacts</h5>
                  </div>
                  <div className="card-body p-2">
                    <div data-simplebar="init" >
                      <div className="simplebar-wrapper">
                        <div className="simplebar-height-auto-observer-wrapper">
                          <div className="simplebar-height-auto-observer"></div>
                        </div>
                        <div className="simplebar-mask">
                          <div className="simplebar-offset">
                            <div className="simplebar-content-wrapper">
                              <div className="simplebar-content">
                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    A
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck1"/>
                                          <label className="custom-control-label" htmlFor="memberCheck1">Albert
                                            Rodarte</label>
                                      </div>
                                    </li>

                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck2"/>
                                          <label className="custom-control-label" htmlFor="memberCheck2">Allison
                                            Etter</label>
                                      </div>
                                    </li>
                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    C
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck3"/>
                                          <label className="custom-control-label" htmlFor="memberCheck3">Craig
                                            Smiley</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    D
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck4"/>
                                          <label className="custom-control-label" htmlFor="memberCheck4">Daniel
                                            Clay</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    I
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck5"/>
                                          <label className="custom-control-label" htmlFor="memberCheck5">Iris
                                            Wells</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    J
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck6"/>
                                          <label className="custom-control-label" htmlFor="memberCheck6">Juan
                                            Flakes</label>
                                      </div>
                                    </li>

                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck7"/>
                                          <label className="custom-control-label" htmlFor="memberCheck7">John
                                            Hall</label>
                                      </div>
                                    </li>

                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck8"/>
                                          <label className="custom-control-label" htmlFor="memberCheck8">Joy
                                            Southern</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    M
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck9"/>
                                          <label className="custom-control-label" htmlFor="memberCheck9">Michael
                                            Hinton</label>
                                      </div>
                                    </li>

                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck10"/>
                                          <label className="custom-control-label" htmlFor="memberCheck10">Mary
                                            Farmer</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    P
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck11"/>
                                          <label className="custom-control-label" htmlFor="memberCheck11">Phillis
                                            Griffin</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    R
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck12"/>
                                          <label className="custom-control-label" htmlFor="memberCheck12">Rocky
                                            Jackson</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>

                                <div>
                                  <div className="p-3 font-weight-bold text-primary">
                                    S
                                  </div>

                                  <ul className="list-unstyled contact-list">
                                    <li>
                                      <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="memberCheck13"/>
                                          <label className="custom-control-label" htmlFor="memberCheck13">Simon
                                            Velez</label>
                                      </div>
                                    </li>

                                  </ul>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div className="simplebar-placeholder"></div>
                      </div>
                      <div className="simplebar-track simplebar-horizontal">
                        <div className="simplebar-scrollbar"></div>
                      </div>
                      <div className="simplebar-track simplebar-vertical">
                        <div className="simplebar-scrollbar"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="form-group">
              <label htmlFor="addgroupdescription-input">Description</label>
              <textarea className="form-control" id="addgroupdescription-input"
                        placeholder="Enter Description"></textarea>
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
