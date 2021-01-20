import React, { FC, useContext } from 'react'

import { EntitiesModal } from '../../types/types'
import { Add } from '../../components/Add/Add'

// import styles from './index.module.scss'
import { Flex } from '@chakra-ui/react'
import { SelectSemesterPopover } from '../../components/ui/Dashboard/SelectSemesterPopover'
import { GlobalDataContext } from '../../components/Auth/Provider'

const App: FC = () => {
  const { setModalType } = useContext(GlobalDataContext)

  const generateAddButtons = () =>
    Object.keys(EntitiesModal).map((value) => (
      <Add
        key={value}
        name={value.toLowerCase()}
        onClick={() => {
          setModalType(EntitiesModal[value])
          console.log('log')
        }}
      />
    ))

  return (
    <>
      {/* <aside className={styles.sidebar}> */}
      {/*  <Link href={"/"}> */}
      {/*    <a>Dashboard</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/calendar"}> */}
      {/*    <a>Calendar</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/subjects"}> */}
      {/*    <a>Subjects</a> */}
      {/*  </Link> */}
      {/*  <Link href={"/projects"}> */}
      {/*    <a>Projects</a> */}
      {/*  </Link> */}
      {/* </aside> */}
      <Flex mt={6} mb={6} mr={20} justifyContent="flex-end">
        <SelectSemesterPopover />
      </Flex>
      <Flex border="2px solid red" justify="space-around">
        {generateAddButtons()}
      </Flex>

      {/* <section className={styles.app}> */}
      {/*  <section className={styles.addSection}>{generateAddButtons()}</section> */}
      {/* </section> */}
    </>
  )
}

// export function getServerSideProps() {
//   const zustandStore = initializeStore()
//
//   return {
//     props: {
//       initialZustandState: JSON.stringify(zustandStore.getState()),
//     },
//   }
// }

export default App
