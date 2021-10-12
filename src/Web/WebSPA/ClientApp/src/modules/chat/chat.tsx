import React, {useState} from "react";
import 'modules/chat/chat.css';
import avatar from "assets/images/users/avatar-4.jpg"
import {Collapse, Dropdown, ListGroup, Nav} from "react-bootstrap";
import { FriendProfile } from "modules/friend/friend-profile"


export const Chat = () => {
  const [open, setOpen] = useState(true);

    return (
        <div className="user-chat w-100">
        <div className="d-lg-flex">
            <div className="w-100">
                <div className="p-3 p-lg-4 border-bottom">
                    <div className="row align-items-center">
                        <div className="col-sm-4 col-8">
                            <div className="media align-items-center">
                                <div className="d-block d-lg-none mr-2">
                                    <a href="#"
                                       className="user-chat-remove text-muted font-size-16 p-2"><i
                                        className="ri-arrow-left-s-line"></i></a>
                                </div>
                                <div className="mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                </div>
                                <div className="media-body overflow-hidden">
                                    <h5 className="font-size-16 mb-0 text-truncate">
                                      <a href="#" className="text-reset user-profile-show">Doris
                                        Brown</a>
                                      <i className="ri-record-circle-fill font-size-10 text-success d-inline-block ml-1"></i>
                                    </h5>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-8 col-4">
                          <ul className="list-inline user-chat-nav text-right mb-0">

                            <li className="list-inline-item">
                              <Dropdown>
                                <Dropdown.Toggle as="button" className="btn nav-btn">
                                  <i className="ri-search-line"></i>
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                  <div className="search-box p-2">
                                    <input type="text" className="form-control bg-light border-0"
                                           placeholder="Search.."/>
                                  </div>
                                </Dropdown.Menu>
                              </Dropdown>
                            </li>
                            <li className="list-inline-item d-none d-lg-inline-block">
                              <button type="button" className="btn nav-btn user-profile-show">
                                <i className="ri-user-2-line"></i>
                              </button>
                            </li>
                            <li className="list-inline-item">
                              <Dropdown>
                                <Dropdown.Toggle as="button" className="btn nav-btn">
                                  <i className="ri-more-fill"></i>
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                  <Dropdown.Item as="li">
                                    <a className="dropdown-item" href="#">Archive <i
                                      className="ri-archive-line float-right text-muted"></i></a>
                                  </Dropdown.Item>
                                  <Dropdown.Item as="li">
                                    <a className="dropdown-item" href="#">Muted <i
                                      className="ri-volume-mute-line float-right text-muted"></i></a>
                                  </Dropdown.Item>
                                  <Dropdown.Item as="li">
                                    <a className="dropdown-item" href="#">Delete <i
                                      className="ri-delete-bin-line float-right text-muted"></i></a>
                                  </Dropdown.Item>
                                </Dropdown.Menu>
                              </Dropdown>
                            </li>
                          </ul>
                        </div>
                    </div>
                </div>
                <div className="chat-conversation p-3 p-lg-4" data-simplebar="init">
                    <div className="simplebar-wrapper">
                        <div className="simplebar-height-auto-observer-wrapper">
                            <div className="simplebar-height-auto-observer"></div>
                        </div>
                        <div className="simplebar-mask">
                            <div className="simplebar-offset" >
                                <div className="simplebar-content-wrapper">
                                    <div className="simplebar-content">
                                        <ul className="list-unstyled mb-0">
                                            <li>
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt=""/>
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    Good morning
                                                                </p>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:00</span></p>
                                                            </div>
                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div className="conversation-name">Doris Brown</div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li className="right">
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt=""/>
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    Good morning, How are you? What about our next
                                                                    meeting?
                                                                </p>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:02</span></p>
                                                            </div>

                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div className="conversation-name">Patricia Smith</div>
                                                    </div>
                                                </div>
                                            </li>

                                            <li>
                                                <div className="chat-day-title">
                                                    <span className="title">Today</span>
                                                </div>
                                            </li>

                                            <li>
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt=""/>
                                                    </div>

                                                    <div className="user-chat-content">

                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    Yeah everything is fine
                                                                </p>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:05</span></p>
                                                            </div>
                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    &amp; Next meeting tomorrow 10.00AM
                                                                </p>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:05</span></p>
                                                            </div>
                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div className="conversation-name">Doris Brown</div>
                                                    </div>

                                                </div>
                                            </li>

                                            <li className="right">
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt=""/>
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    Wow that's great
                                                                </p>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:06</span></p>
                                                            </div>
                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div className="conversation-name">Patricia Smith</div>
                                                    </div>

                                                </div>
                                            </li>

                                            <li>
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt=""/>
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">

                                                            <div className="ctext-wrap-content">
                                                                <ul className="list-inline message-img  mb-0">
                                                                    <li className="list-inline-item message-img-list">
                                                                        <div>
                                                                            <a className="popup-img d-inline-block m-1"
                                                                               href={avatar}
                                                                               title="Project 1">
                                                                                <img src={avatar}
                                                                                     alt="" className="rounded border"/>
                                                                            </a>
                                                                        </div>
                                                                        <div className="message-img-link">
                                                                            <ul className="list-inline mb-0">
                                                                                <li className="list-inline-item">
                                                                                    <a href="#">
                                                                                        <i className="ri-download-2-line"></i>
                                                                                    </a>
                                                                                </li>
                                                                                <li className="list-inline-item dropdown">
                                                                                    <a className="dropdown-toggle"
                                                                                       href="#" role="button"
                                                                                       data-toggle="dropdown"
                                                                                       aria-haspopup="true"
                                                                                       aria-expanded="false">
                                                                                        <i className="ri-more-fill"></i>
                                                                                    </a>
                                                                                    <div className="dropdown-menu">
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Copy <i
                                                                                            className="ri-file-copy-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Save <i
                                                                                            className="ri-save-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Forward <i
                                                                                            className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Delete <i
                                                                                            className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </li>

                                                                    <li className="list-inline-item message-img-list">
                                                                        <div>
                                                                            <a className="popup-img d-inline-block m-1"
                                                                               href={avatar}
                                                                               title="Project 2">
                                                                                <img src={avatar}
                                                                                     alt="" className="rounded border"/>
                                                                            </a>
                                                                        </div>
                                                                        <div className="message-img-link">
                                                                            <ul className="list-inline mb-0">
                                                                                <li className="list-inline-item">
                                                                                    <a href="#">
                                                                                        <i className="ri-download-2-line"></i>
                                                                                    </a>
                                                                                </li>
                                                                                <li className="list-inline-item dropdown">
                                                                                    <a className="dropdown-toggle"
                                                                                       href="#" role="button"
                                                                                       data-toggle="dropdown"
                                                                                       aria-haspopup="true"
                                                                                       aria-expanded="false">
                                                                                        <i className="ri-more-fill"></i>
                                                                                    </a>
                                                                                    <div className="dropdown-menu">
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Copy <i
                                                                                            className="ri-file-copy-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Save <i
                                                                                            className="ri-save-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Forward <i
                                                                                            className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Delete <i
                                                                                            className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:09</span></p>
                                                            </div>

                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div className="conversation-name">Doris Brown</div>
                                                    </div>

                                                </div>
                                            </li>

                                            <li className="right">
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt="" />
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">

                                                            <div className="ctext-wrap-content">
                                                                <div className="card p-2 mb-2">
                                                                    <div className="media align-items-center">
                                                                        <div className="avatar-sm mr-3">
                                                                            <div
                                                                                className="avatar-title bg-soft-primary text-primary rounded font-size-20">
                                                                                <i className="ri-file-text-fill"></i>
                                                                            </div>
                                                                        </div>
                                                                        <div className="media-body">
                                                                            <div className="text-left">
                                                                                <h5 className="font-size-14 mb-1">admin_v1.0.zip</h5>
                                                                                <p className="text-muted font-size-13 mb-0">12.5
                                                                                    MB</p>
                                                                            </div>
                                                                        </div>

                                                                        <div className="ml-4">
                                                                            <ul className="list-inline mb-0 font-size-20">
                                                                                <li className="list-inline-item">
                                                                                    <a href="#" className="text-muted">
                                                                                        <i className="ri-download-2-line"></i>
                                                                                    </a>
                                                                                </li>
                                                                                <li className="list-inline-item dropdown">
                                                                                    <a className="dropdown-toggle text-muted"
                                                                                       href="#" role="button"
                                                                                       data-toggle="dropdown"
                                                                                       aria-haspopup="true"
                                                                                       aria-expanded="false">
                                                                                        <i className="ri-more-fill"></i>
                                                                                    </a>
                                                                                    <div
                                                                                        className="dropdown-menu dropdown-menu-right">
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Share <i
                                                                                            className="ri-share-line float-right text-muted"></i></a>
                                                                                        <a className="dropdown-item"
                                                                                           href="#">Delete <i
                                                                                            className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <p className="chat-time mb-0"><i
                                                                    className="ri-time-line align-middle"></i> <span
                                                                    className="align-middle">10:16</span></p>
                                                            </div>

                                                            <div className="dropdown align-self-start">
                                                                <a className="dropdown-toggle" href="#" role="button"
                                                                   data-toggle="dropdown" aria-haspopup="true"
                                                                   aria-expanded="false">
                                                                    <i className="ri-more-2-fill"></i>
                                                                </a>
                                                                <div className="dropdown-menu">
                                                                    <a className="dropdown-item" href="#">Copy <i
                                                                        className="ri-file-copy-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Save <i
                                                                        className="ri-save-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Forward <i
                                                                        className="ri-chat-forward-line float-right text-muted"></i></a>
                                                                    <a className="dropdown-item" href="#">Delete <i
                                                                        className="ri-delete-bin-line float-right text-muted"></i></a>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div className="conversation-name">Patricia Smith</div>
                                                    </div>

                                                </div>
                                            </li>

                                            <li>
                                                <div className="conversation-list">
                                                    <div className="chat-avatar">
                                                        <img src={avatar} alt="" />
                                                    </div>

                                                    <div className="user-chat-content">
                                                        <div className="ctext-wrap">
                                                            <div className="ctext-wrap-content">
                                                                <p className="mb-0">
                                                                    typing
                                                                    <span className="animate-typing">
                                                            <span className="dot"></span>
                                                            <span className="dot"></span>
                                                            <span className="dot"></span>
                                                        </span>
                                                                </p>
                                                            </div>
                                                        </div>

                                                        <div className="conversation-name">Doris Brown</div>
                                                    </div>

                                                </div>
                                            </li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="simplebar-placeholder" ></div>
                    </div>
                    <div className="simplebar-track simplebar-horizontal" >
                        <div className="simplebar-scrollbar"></div>

                    </div>
                    <div className="simplebar-track simplebar-vertical" >
                        <div className="simplebar-scrollbar"></div>
                    </div>
                </div>


                <div className="p-3 p-lg-4 border-top mb-0">
                    <div className="row no-gutters">
                        <div className="col">
                            <div>
                                <input type="text" className="form-control form-control-lg bg-light border-light"
                                       placeholder="Enter Message..." />
                            </div>
                        </div>
                        <div className="col-auto">
                            <div className="chat-input-links ml-md-2">
                                <ul className="list-inline mb-0">
                                    <li className="list-inline-item">
                                        <button type="button"
                                                className="btn btn-link text-decoration-none font-size-16 btn-lg waves-effect"
                                                data-toggle="tooltip" data-placement="top" title=""
                                                data-original-title="Emoji">
                                            <i className="ri-emotion-happy-line"></i>
                                        </button>
                                    </li>
                                    <li className="list-inline-item">
                                        <button type="button"
                                                className="btn btn-link text-decoration-none font-size-16 btn-lg waves-effect"
                                                data-toggle="tooltip" data-placement="top" title=""
                                                data-original-title="Attached File">
                                            <i className="ri-attachment-line"></i>
                                        </button>
                                    </li>
                                    <li className="list-inline-item">
                                        <button type="submit"
                                                className="btn btn-primary font-size-16 btn-lg chat-send waves-effect waves-light">
                                            <i className="ri-send-plane-2-fill"></i>
                                        </button>
                                    </li>
                                </ul>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <FriendProfile/>
        </div>
    </div>)
}
