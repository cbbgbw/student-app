import React, {
  createContext,
  FC,
  useEffect,
  useLayoutEffect,
  useState,
} from 'react'
import { useRouter } from 'next/router'
import { ModalWrapper } from '../../../forms/ModalWrapper'
import LoadingPage from '../../page/LoadingPage'
import { ModalType } from '../../../types/types'
import { Navigation } from '../../Navigation/Navigation'
import { Flex } from '@chakra-ui/layout'
import { Search } from '../../Search'
import { Box } from '@chakra-ui/react'

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
  const [isLogin, setIsLogin] = useState(false)

  const withoutAuth = ['/login', '/register']
  const isPageWithoutAuth = withoutAuth.includes(pathname)

  useEffect(() => {
    let token = localStorage.getItem('token')
    const isAbleToAuthorize = token && token !== ''

    if (!isAbleToAuthorize && !isPageWithoutAuth) {
      push('/login')
    }
    setIsLogin(!!isAbleToAuthorize)
  }, [])

  if (!isLogin && !isPageWithoutAuth) {
    return <LoadingPage />
  }
  return (
    <GlobalDataProvider>
      {isPageWithoutAuth ? (
        props.children
      ) : (
        <Flex flexDir="row">
          {!isPageWithoutAuth && <Navigation />}
          <Box pl="60px" pr="60px" w="100%" h="100h" backgroundColor="#DCDAF2">
            <Search />
            {props.children}
          </Box>
          <ModalWrapper />
        </Flex>
      )}
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
