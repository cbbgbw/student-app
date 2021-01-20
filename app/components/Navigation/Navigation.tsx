import React, { FC } from 'react'
import { Box, Flex } from '@chakra-ui/react'
import { useAuth } from '../../hooks/useAuth'

export const navWidth = 100
export const Navigation: FC = () => {
  const { mutateSemester } = useAuth()

  const navigationList = [
    {
      name: 'Pulpit',
      href: '/app',
    },
    {
      name: 'Przedmioty',
      href: '/subjects',
    },
  ]

  return (
    <Box paddingTop={20}>
      <Flex pos="absolute" top={0} w="100vw" border="2px solid red" h={20} />
      {/* <Flex padding={25} justify="flex-end"> */}
      {/*  <CSelect mr={15} maxW={200}> */}
      {/*    {generateSemesters()} */}
      {/*  </CSelect> */}
      {/*  <Menu placement="bottom-start"> */}
      {/*    <MenuButton background="transparent" as={Button}> */}
      {/*      <AccountIcon /> */}
      {/*    </MenuButton> */}
      {/*    <MenuList> */}
      {/*      <MenuItem>Wyloguj</MenuItem> */}
      {/*    </MenuList> */}
      {/*  </Menu> */}
      {/*  <style jsx> */}
      {/*    {` */}
      {/*      .topBar { */}
      {/*        position: absolute; */}
      {/*        top: 0; */}
      {/*        right: 0; */}
      {/*      } */}
      {/*    `} */}
      {/*  </style> */}
      {/* </Flex> */}
      {/* <aside className="app-navigation"> */}
      {/*  <ul> */}
      {/*    {navigationList.map((el) => ( */}
      {/*      <li key={el.name}>Icon</li> */}
      {/*    ))} */}
      {/*    <button className="cyberpunk">Hype the beast</button> */}
      {/*  </ul> */}
      {/*  <style jsx> */}
      {/*    {` */}
      {/*      .app-navigation { */}
      {/*        position: absolute; */}
      {/*        height: 100%; */}
      {/*        left: 0; */}
      {/*        top: 0; */}

      {/*        border: 1px solid red; */}
      {/*        width: ${navWidth}px; */}
      {/*        box-sizing: border-box; */}
      {/*      } */}

      {/*      .cyberpunk { */}
      {/*        background: ${CyberpunkTheme.Black}; */}
      {/*        color: ${CyberpunkTheme.Pantone}; */}
      {/*      } */}
      {/*    `} */}
      {/*  </style> */}
      {/* </aside> */}
    </Box>
  )
}
