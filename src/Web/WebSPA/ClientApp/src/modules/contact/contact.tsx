import React, {useState} from 'react';
import 'modules/contact/contact.css';
import {CreateContactModal} from "modules/contact/create-contact-modal";

const Contact = () =>  {
  const [open, setOpen] = useState(false);
  const handleClose = () => setOpen(false);

  return(
      <div className="tab-pane active" id="pills-contacts" role="tabpanel" aria-labelledby="pills-contacts-tab">
        <div>
          <div className="p-4">
            <div className="user-chat-nav float-right">
              <div data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Add Contact">
                <button type="button"   onClick={()=>setOpen(true)}  className="btn btn-link text-decoration-none text-muted font-size-18 py-0">
                  <i className="ri-user-add-line"></i>
                </button>
              </div>
            </div>
            <h4 className="mb-4">Contacts</h4>

            <CreateContactModal HandleClose={handleClose} Open={open} Title="Add Contact"/>

            <div className="search-box chat-search-box">
              <div className="input-group bg-light  input-group-lg rounded-lg">
                <div className="input-group-prepend">
                  <button className="btn btn-link text-decoration-none text-muted pr-1" type="button">
                    <i className="ri-search-line search-icon font-size-18"></i>
                  </button>
                </div>
                <input type="text" className="form-control bg-light " placeholder="Search users.."/>
              </div>
            </div>
            </div>
          <div className="p-4 chat-message-list chat-group-list" data-simplebar="init">
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
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Albert Rodarte</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Allison Etter</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>

                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          C
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Craig Smiley</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>

                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          D
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Daniel Clay</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Doris Brown</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>
                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          I
                        </div>
                        <ul className="list-unstyled contact-list">

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Iris Wells</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>

                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          J
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Juan Flakes</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">John Hall</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Joy Southern</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                        </ul>
                      </div>
                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          M
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Mary Farmer</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Mark Messer</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Michael Hinton</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                        </ul>
                      </div>
                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          O
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Ossie Wilson</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                        </ul>
                      </div>

                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          P
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Phillis Griffin</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Paul Haynes</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                        </ul>
                      </div>
                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          R
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Rocky Jackson</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>

                        </ul>
                      </div>
                      <div className="mt-3">
                        <div className="p-3 font-weight-bold text-primary">
                          S
                        </div>

                        <ul className="list-unstyled contact-list">
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Sara Muller</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Simon Velez</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
                            </div>
                          </li>
                          <li>
                            <div className="media align-items-center">
                              <div className="media-body">
                                <h5 className="font-size-14 m-0">Steve Walker</h5>
                              </div>

                              <div className="dropdown">
                                <a href="#" className="text-muted dropdown-toggle" data-toggle="dropdown"
                                   aria-haspopup="true" aria-expanded="false">
                                  <i className="ri-more-2-fill"></i>
                                </a>
                                <div className="dropdown-menu dropdown-menu-right">
                                  <a className="dropdown-item" href="#">Share <i
                                    className="ri-share-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Block <i
                                    className="ri-forbid-line float-right text-muted"></i></a>
                                  <a className="dropdown-item" href="#">Remove <i
                                    className="ri-delete-bin-line float-right text-muted"></i></a>
                                </div>
                              </div>
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
        )
}

export  default  Contact;
