import React, { createContext, FC, useEffect, useState } from 'react'
import { useRouter } from 'next/router'
import { ModalWrapper } from '../../../forms/ModalWrapper'
import LoadingPage from '../../page/LoadingPage'
import { useStore } from '../../../utils/storeProvider'
import { setSemesters } from '../../../store/modules/user/userSelectors'
import { ModalType } from '../../../types/types'
import { useStateWithLocalStorage } from '../../../hooks/useStateWithLocalStorage'

interface GlobalDataContext {
  modalType: ModalType
  setModalType: (modalType: ModalType) => void
}
export const GlobalDataContext = createContext<GlobalDataContext>({
  modalType: ModalType.AddSubject,
  setModalType: () => {},
})

export const GlobalDataProvider: FC = (props) => {
  const [modalType, setModalType] = useState(ModalType.None)

  return (
    <GlobalDataContext.Provider value={{ modalType, setModalType }}>
      {props.children}
    </GlobalDataContext.Provider>
  )
}

export const AuthProvider: FC = (props) => {
  const { pathname, push } = useRouter()
  const [token] = useStateWithLocalStorage('token')
  const isAbleToAuthorize = token && token !== ''
  const withoutAuth = ['/login', '/register']
  const isPageWithoutAuth = withoutAuth.includes(pathname)

  useEffect(() => {
    if (!isAbleToAuthorize && !isPageWithoutAuth) {
      push('/login')
    }
  }, [token])

  if (!isAbleToAuthorize && !isPageWithoutAuth) {
    return <LoadingPage />
  }
  return (
    <GlobalDataProvider>
      {props.children}
      <ModalWrapper />
    </GlobalDataProvider>
  )

  // const semesterKeys = semesters && Object.keys(semesters)

  // useEffect(() => {
  //   if (semesters && semesterKeys) {
  //     setSemestersLocal(semesters)
  //     if (semesterKeys.length === 0) {
  //       push('/login')
  //     } else if (semesterKeys.length > 0 && pathRequested) {
  //       push(pathRequested)
  //     }
  //   }
  // }, [semesters])

  // return pathname === 'register' ? (
  //   <LoadingPage />
  // ) : (
}

// source https://blog.logrocket.com/using-authentication-in-next-js/
