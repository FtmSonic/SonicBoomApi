import React, { useEffect, useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { createWeb3Modal, defaultConfig, useWeb3ModalAccount } from '@web3modal/ethers/react'

// 1. Get projectId at https://cloud.walletconnect.com
const projectId = 'a5e55d64631f3df3c17291374205286e'

// 2. Set chains
const ftmSonicTestnet = {
    chainId: 64165,
    name: 'Fantom Sonic Open',
    currency: 'FTM',
    explorerUrl: 'https://public-sonic.fantom.network',
    rpcUrl: 'https://rpc.sonic.fantom.network'
}

// 3. Create modal
const metadata = {
    name: 'My Website',
    description: 'My Website description',
    url: 'https://mywebsite.com',
    icons: ['https://avatars.mywebsite.com/']
}

createWeb3Modal({
    ethersConfig: defaultConfig({ metadata }),
    chains: [ftmSonicTestnet],
    projectId
})


const NavMenu = () => {
    const [collapsed, setCollapsed] = useState<boolean>(true);
    const toggleNavbar = () => setCollapsed(!collapsed);

    const { address, chainId, isConnected } = useWeb3ModalAccount()

    useEffect(() => {
        if (isConnected) {
            alert("Connection");
        } else {

        }
    }, [isConnected])

    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand tag={Link} to="/">Sonic Boom</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                            </NavItem>
                            <NavItem>
                                <w3m-button />
                            </NavItem>
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );
}

export { NavMenu };
